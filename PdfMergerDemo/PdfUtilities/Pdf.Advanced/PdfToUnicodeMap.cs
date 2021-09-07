#define GDI


using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PdfSharp.Fonts;
using PdfSharp.Pdf.Filters;

namespace PdfSharp.Pdf.Advanced
{
    /// <summary>
    /// Represents a ToUnicode map for composite font.
    /// </summary>
    internal sealed class PdfToUnicodeMap : PdfDictionary
    {
        public PdfToUnicodeMap(PdfDocument document)
            : base(document)
        { }

        public PdfToUnicodeMap(PdfDocument document, CMapInfo cmapInfo)
            : base(document)
        {
            _cmapInfo = cmapInfo;
        }

        /// <summary>
        /// Gets or sets the CMap info.
        /// </summary>
        public CMapInfo CMapInfo
        {
            get { return _cmapInfo; }
            set { _cmapInfo = value; }
        }
        CMapInfo _cmapInfo;

        /// <summary>
        /// Creates the ToUnicode map from the CMapInfo.
        /// </summary>
        internal override void PrepareForSave()
        {
            base.PrepareForSave();

            // This code comes literally from PDF Reference
            string prefix =
              "/CIDInit /ProcSet findresource begin\n" +
              "12 dict begin\n" +
              "begincmap\n" +
              "/CIDSystemInfo << /Registry (Adobe)/Ordering (UCS)/Supplement 0>> def\n" +
              "/CMapName /Adobe-Identity-UCS def /CMapType 2 def\n";
            string suffix = "endcmap CMapName currentdict /CMap defineresource pop end end";

            Dictionary<int, char> glyphIndexToCharacter = new Dictionary<int, char>();
            int lowIndex = 65536, hiIndex = -1;
            foreach (KeyValuePair<char, int> entry in _cmapInfo.CharacterToGlyphIndex)
            {
                int index = (int)entry.Value;
                lowIndex = Math.Min(lowIndex, index);
                hiIndex = Math.Max(hiIndex, index);
                //glyphIndexToCharacter.Add(index, entry.Key);
                glyphIndexToCharacter[index] = entry.Key;
            }

            MemoryStream ms = new MemoryStream();
#if !SILVERLIGHT && !NETFX_CORE
            StreamWriter wrt = new StreamWriter(ms, Encoding.ASCII);
#else
            StreamWriter wrt = new StreamWriter(ms, Encoding.UTF8);
#endif
            wrt.Write(prefix);

            wrt.WriteLine("1 begincodespacerange");
            wrt.WriteLine(String.Format("<{0:X4}><{1:X4}>", lowIndex, hiIndex));
            wrt.WriteLine("endcodespacerange");

            // Sorting seems not necessary. The limit is 100 entries, we will see.
            wrt.WriteLine(String.Format("{0} beginbfrange", glyphIndexToCharacter.Count));
            foreach (KeyValuePair<int, char> entry in glyphIndexToCharacter)
                wrt.WriteLine(String.Format("<{0:X4}><{0:X4}><{1:X4}>", entry.Key, (int)entry.Value));
            wrt.WriteLine("endbfrange");

            wrt.Write(suffix);
#if !UWP
            wrt.Close();
#else
            wrt.Dispose();
#endif

            // Compress like content streams
            byte[] bytes = ms.ToArray();
#if !UWP
            ms.Close();
#else
            ms.Dispose();
#endif
            if (Owner.Options.CompressContentStreams)
            {
                Elements.SetName("/Filter", "/FlateDecode");
                bytes = Filtering.FlateDecode.Encode(bytes, _document.Options.FlateEncodeMode);
            }
            //PdfStream stream = CreateStream(bytes);
            else
            {
                Elements.Remove("/Filter");
            }

            if (Stream == null)
                CreateStream(bytes);
            else
            {
                Stream.Value = bytes;
                Elements.SetInteger(PdfStream.Keys.Length, Stream.Length);
            }
        }

        public sealed class Keys : PdfStream.Keys
        {
            // No new keys.
        }
    }
}
