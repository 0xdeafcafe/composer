using System;
using System.Collections.Generic;
using Blamite.Blam.Shaders;
using Blamite.IO;
using Blamite.Plugins;
using Blamite.Util;
using Composer.Models;
using Composer.Models.ParsedTag;
using Composer.Models.ParsedTag.ValueTypes;
using Composer.Models.ParsedTag.ValueTypes.Abstracts;

namespace Composer.Commands.Project.Plugins
{
	public class JsonPluginVisitor : IPluginVisitor
	{
		public TagData TagData { get; set; } = new TagData();
		private readonly FileSegmentGroup _metaArea;
		private readonly IList<PluginRevision> _pluginRevisions = new List<PluginRevision>();
		//private readonly List<ReflexiveData> _reflexives = new List<ReflexiveData>();
		private readonly Trie _stringIDTrie;
		private readonly IEnumerable<TagEntry> _tags;
		private BitfieldData _currentBitfield;
		private EnumData _currentEnum;
		// private ReflexiveData _currentReflexive;

		public bool ShowComments
		{
			get { return true; }
		}
		
		public JsonPluginVisitor(IEnumerable<TagEntry> tags, Trie stringIDTrie, FileSegmentGroup metaArea)
		{
			_tags = tags;
			_stringIDTrie = stringIDTrie;
			_metaArea = metaArea;

			// Reflexives = new ObservableCollection<ReflexiveData>();
		}

		// Public Members
		public IList<PluginRevision> PluginRevisions
		{
			get { return _pluginRevisions; }
		}

		// public ObservableCollection<ReflexiveData> Reflexives { get; private set; }

		public bool EnterPlugin(int baseSize)
		{
			return true;
		}

		public void LeavePlugin() { }

		public void VisitComment(string title, string text, uint pluginLine)
		{
			// if (ShowComments)
			// 	AddValue(new CommentData(title, text, pluginLine));
		}

		public void VisitVector3(string name, uint offset, bool visible, uint pluginLine)
		{
			// if (visible || _showInvisibles)
			// 	AddValue(new VectorData(name, offset, 0, 0, 0, 0, pluginLine));
		}

		public void VisitDegree(string name, uint offset, bool visible, uint pluginLine)
		{
			// if (visible || _showInvisibles)
			// 	AddValue(new DegreeData(name, offset, 0, 0, pluginLine));
		}

		public void VisitRange(string name, uint offset, bool visible, string type, double minval, double maxval,
			double smallchange, double largechange, uint pluginLine)
		{
			/*TrackBar metaComponents = new TrackBar();
			metaComponents.LoadValues(name, type, minval, maxval, smallchange, largechange);

			AddUIElement(metaComponents, visible);*/
		}

		public void VisitColorInt(string name, uint offset, bool visible, string format, uint pluginLine)
		{
			// 	AddValue(new ColourData(name, offset, 0, format, "int", "", pluginLine));
		}

		public void VisitColorF(string name, uint offset, bool visible, string format, uint pluginLine)
		{
			// 	AddValue(new ColourData(name, offset, 0, format, "float", "", pluginLine));
		}

		public void VisitStringID(string name, uint offset, bool visible, uint pluginLine)
		{
			// 	AddValue(new StringIDData(name, offset, 0, "", _stringIDTrie, pluginLine));
		}

		public void VisitAscii(string name, uint offset, bool visible, int size, uint pluginLine)
		{
			// 	AddValue(new StringData(name, offset, 0, StringType.ASCII, "", size, pluginLine));
		}

		public void VisitUtf16(string name, uint offset, bool visible, int size, uint pluginLine)
		{
			// 	AddValue(new StringData(name, offset, 0, StringType.UTF16, "", size, pluginLine));
		}

		public void VisitRawData(string name, uint offset, bool visible, int size, uint pluginLine)
		{
			// 	AddValue(new RawData(name, offset, "bytes", 0, "", size, pluginLine));
		}

		public void VisitTagReference(string name, uint offset, bool visible, bool withClass, bool showJumpTo, uint pluginLine)
		{
			// Visibility jumpTo = showJumpTo
			// 	? Visibility.Visible
			// 	: Visibility.Hidden;

			// AddValue(new TagRefData(name, offset, 0, _tags, jumpTo, withClass, pluginLine));
		}

		public void VisitDataReference(string name, uint offset, string format, bool visible, int align, uint pluginLine)
		{
			// 	AddValue(new DataRef(name, offset, format, 0, 0, "", 0, pluginLine));
		}

		public void VisitShader(string name, uint offset, bool visible, ShaderType type, uint pluginLine)
		{
			// 	AddValue(new ShaderRef(name, offset, 0, type, null, pluginLine));
		}

		public void VisitUnicList(string name, uint offset, bool visible, int languages, uint pluginLine)
		{
			// for (var i = 0; i < languages; i++)
			// {
			// 	AddValue(new Uint16Data("Language " + i + " " + name + " Index", (uint)(offset + i * 4), 0, "uint16", 0, pluginLine));
			// 	AddValue(new Uint16Data("Language " + i + " " + name + " Count", (uint)(offset + i * 4 + 2), 0, "uint16", 0, pluginLine));
			// }
		}

		#region Bitfield

		public bool EnterBitfield8(string name, uint offset, bool visible, uint pluginLine)
		{
			return EnterBitfield(BitfieldType.Bitfield8, name, offset, visible, pluginLine);
		}

		public bool EnterBitfield16(string name, uint offset, bool visible, uint pluginLine)
		{
			return EnterBitfield(BitfieldType.Bitfield16, name, offset, visible, pluginLine);
		}

		public bool EnterBitfield32(string name, uint offset, bool visible, uint pluginLine)
		{
			return EnterBitfield(BitfieldType.Bitfield32, name, offset, visible, pluginLine);
		}

		public void VisitBit(string name, int index)
		{
			// if (_currentBitfield != null)
			// 	_currentBitfield.DefineBit(index, name);
			// else
			// 	throw new InvalidOperationException("Cannot add a bit to a non-existant bitfield");
		}

		public void LeaveBitfield()
		{
			if (_currentBitfield == null)
				throw new InvalidOperationException("Cannot leave a bitfield if one isn't active");

			AddValue(_currentBitfield);
			_currentBitfield = null;
		}

		private bool EnterBitfield(BitfieldType type, string name, uint offset, bool visible, uint pluginLine)
		{
			_currentBitfield = new BitfieldData(name, offset, 0, type);
			return true;
		}

		#endregion

		#region Enum

		public bool EnterEnum8(string name, uint offset, bool visible, uint pluginLine)
		{
			return EnterEnum(EnumType.Enum8, name, offset, visible, pluginLine);
		}

		public bool EnterEnum16(string name, uint offset, bool visible, uint pluginLine)
		{
			return EnterEnum(EnumType.Enum16, name, offset, visible, pluginLine);
		}

		public bool EnterEnum32(string name, uint offset, bool visible, uint pluginLine)
		{
			return EnterEnum(EnumType.Enum32, name, offset, visible, pluginLine);
		}

		public void VisitOption(string name, int value)
		{
			// if (_currentEnum != null)
			// 	_currentEnum.Values.Add(new EnumValue(name, value));
			// else
			// 	throw new InvalidOperationException("Cannot add an option to a non-existant enum");
		}

		public void LeaveEnum()
		{
			if (_currentEnum == null)
				throw new InvalidOperationException("Cannot leave an enum if one isn't active");

			AddValue(_currentEnum);
			_currentEnum = null;
		}

		private bool EnterEnum(EnumType type, string name, uint offset, bool visible, uint pluginLine)
		{
			_currentEnum = new EnumData(name, offset, 0, type, 0);
			return true;
		}

		#endregion

		#region Reflexive

		public bool EnterReflexive(string name, uint offset, bool visible, uint entrySize, int align, uint pluginLine)
		{
			return false;
			// 	var data = new ReflexiveData(name, offset, 0, entrySize, align, pluginLine, _metaArea);
			// 	AddValue(data);

			// 	_reflexives.Add(data);
			// 	Reflexives.Add(data);
			// 	_currentReflexive = data;
			// 	return true;
		}

		public void LeaveReflexive()
		{
			// if (_currentReflexive == null)
			// 	throw new InvalidOperationException("Not in a reflexive");

			// _reflexives.RemoveAt(_reflexives.Count - 1);
			// _currentReflexive = _reflexives.Count > 0 ? _reflexives[_reflexives.Count - 1] : null;
		}

		#endregion

		#region Integers

		public void VisitUInt8(string name, uint offset, bool visible, uint pluginLine)
		{
			AddValue(new UInt8Data(name, offset, 0, "uint8", 0));
		}

		public void VisitInt8(string name, uint offset, bool visible, uint pluginLine)
		{
			AddValue(new Int8Data(name, offset, 0, "int8", 0));
		}

		public void VisitUInt16(string name, uint offset, bool visible, uint pluginLine)
		{
			AddValue(new UInt16Data(name, offset, 0, "uint16", 0));
		}

		public void VisitInt16(string name, uint offset, bool visible, uint pluginLine)
		{
			AddValue(new Int16Data(name, offset, 0, "int16", 0));
		}

		public void VisitUInt32(string name, uint offset, bool visible, uint pluginLine)
		{
			AddValue(new UInt32Data(name, offset, 0, "uint32", 0));
		}

		public void VisitInt32(string name, uint offset, bool visible, uint pluginLine)
		{
			AddValue(new Int32Data(name, offset, 0, "int32", 0));
		}

		public void VisitFloat32(string name, uint offset, bool visible, uint pluginLine)
		{
			AddValue(new FloatData(name, offset, 0, "float32", 0));
		}

		public void VisitUndefined(string name, uint offset, bool visible, uint pluginLine)
		{
			AddValue(new FloatData(name, offset, 0, "undefined", 0));
		}

		#endregion

		#region Revisions

		public bool EnterRevisions()
		{
			return true;
		}

		public void VisitRevision(PluginRevision revision)
		{
			TagData.Revisions.Add(new TagRevision(revision));
		}

		public void LeaveRevisions() { }

		#endregion

		private void AddValue(ValueField /*MetaField*/ value)
		{
			// if (_reflexives.Count > 0)
			// 	_reflexives[_reflexives.Count - 1].Template.Add(value);
			// else
				TagData.Fields.Add(value);

			/*MetaField wrappedValue = value;
			for (int i = _reflexives.Count - 1; i >= 0; i--)
			{
				ReflexiveData reflexive = _reflexives[i];
				reflexive.Pages[0].Fields.Add(wrappedValue);

				// hax, use a null parent for now so MetaReader doesn't have to cause it to unsubscribe
				wrappedValue = new WrappedReflexiveEntry(null, reflexive.Pages[0].Fields.Count - 1);
			}

			Values.Add(wrappedValue);*/
		}
	}
}
