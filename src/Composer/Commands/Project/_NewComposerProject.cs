using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Blamite.Blam;
using Blamite.IO;
using Blamite.Serialization;
using Blamite.Serialization.Settings;
using Blamite.Util;
using Composer.Commands.Project.Plugins;
using Composer.Exceptions;
using Composer.Helpers;
using Composer.Models;
using Newtonsoft.Json;

namespace Composer.Commands.Project
{
	public partial class ComposerProject
	{
		public static async Task Create(Dictionary<string, string> arguments, Dictionary<string, string> options)
		{
			await Task.Delay(1);
			var cacheFilePath = arguments["cache"];
			var projectDirectory = arguments["project"];

			// Check file exists
			if (cacheFilePath == null || !File.Exists(cacheFilePath))
				throw new ComposerException("Cache doesn't exist");

			// Create project directory
			// TODO: think about logic if directory already exists
			if (!Directory.Exists(projectDirectory))
				Directory.CreateDirectory(projectDirectory);

			// Create Project
			var project = new Models.Project
			{
				Title = "Example Halo Project",
				Version = "1.0.0",
				Description = "Simple project for testing the tool",
				Properties = new ProjectProperties
				{
					TagsFolder = "tags",
					GitEnabled = true
				}
			};

			using (var stream = File.OpenRead(cacheFilePath))
			using (var reader = new EndianReader(stream, Endian.BigEndian))
			{
				EngineDescription engineDescription = null;
				EngineDatabase engineDatabase = XMLEngineDatabaseLoader.LoadDatabase("data/formats/engines.xml");
				var cacheFile = CacheFileLoader.LoadCacheFile(reader, engineDatabase, out engineDescription);
				var stringIdTrie = new Trie();
				if (cacheFile.StringIDs != null) stringIdTrie.AddRange(cacheFile.StringIDs);

				if (cacheFile.TagClasses.Any())
					LoadTags(project, cacheFile, projectDirectory, stringIdTrie);
			}

			File.WriteAllText(Path.Combine(projectDirectory, "project.json"), JsonConvert.SerializeObject(project, Formatting.Indented));
		}

		public static void LoadTags(Models.Project project, ICacheFile cacheFile,
			string projectDirectory, Trie stringIdTrie)
		{
			var tagsDirectory = Path.Combine(projectDirectory, project.Properties.TagsFolder);
			if (!Directory.Exists(tagsDirectory))
				Directory.CreateDirectory(tagsDirectory);

			// Generate Tag List 
			var tags = cacheFile.Tags
				.Where(tag => tag != null && tag.Class != null && tag.MetaLocation != null)
				.Select(tag =>
				{
					var className = CharConstant.ToString(tag.Class.Magic).Trim();
					var name = cacheFile.FileNames.GetTagName(tag);
					if (string.IsNullOrWhiteSpace(name)) name = tag.Index.ToString();

					var directory = tagsDirectory;
					var tagFileName = $"{name}.{className}";
					var indexOfSeparator = tagFileName.LastIndexOf('\\');
					if (indexOfSeparator > -1)
					{
						directory = Path
							.Combine(tagsDirectory, tagFileName.Remove(indexOfSeparator))
							.Replace('\\', Path.DirectorySeparatorChar);

						tagFileName = tagFileName.Remove(0, indexOfSeparator + 1);
					}

					return new TagEntry(tag, className, name, tagFileName, directory);
				});

			// Extract Tag Data
			foreach (var tag in tags)
			{
				// Create Directory
				if (!Directory.Exists(tag.Directory))
					Directory.CreateDirectory(tag.Directory);

				using (var reader = XmlReader.Create($"data/plugins/halo3/{PlatformHelpers.EscapePath(tag.ClassName)}.xml"))
				{
					var pluginVisitor = new JsonPluginVisitor(tags, stringIdTrie, cacheFile.MetaArea);
					JsonPluginLoader.LoadPlugin(reader, pluginVisitor);

					File.WriteAllText(tag.FullPath, 
						JsonConvert.SerializeObject(pluginVisitor.TagData, Formatting.Indented, new JsonSerializerSettings
						{
							TypeNameHandling = TypeNameHandling.Auto
						}));
				}
			}
		}
	}
}
