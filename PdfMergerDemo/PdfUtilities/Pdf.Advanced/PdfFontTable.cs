#define GDI


using System.Diagnostics;
using System.Collections.Generic;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Advanced
{
    internal enum FontType
    {
        /// <summary>
        /// TrueType with WinAnsi encoding.
        /// </summary>
        TrueType = 1,

        /// <summary>
        /// TrueType with Identity-H or Identity-V encoding (unicode).
        /// </summary>
        Type0 = 2,
    }

    /// <summary>
    /// Contains all used fonts of a document.
    /// </summary>
    internal sealed class PdfFontTable : PdfResourceTable
    {
        /// <summary>
        /// Initializes a new instance of this class, which is a singleton for each document.
        /// </summary>
        public PdfFontTable(PdfDocument document)
            : base(document)
        { }

        /// <summary>
        /// Gets a PdfFont from an XFont. If no PdfFont already exists, a new one is created.
        /// </summary>
        public PdfFont GetFont(XFont font)
        {
            string selector = font.Selector;
            if (selector == null)
            {
                selector = ComputeKey(font); //new FontSelector(font);
                font.Selector = selector;
            }
            PdfFont pdfFont;
            if (!_fonts.TryGetValue(selector, out pdfFont))
            {
                if (font.Unicode)
                    pdfFont = new PdfType0Font(Owner, font, font.IsVertical);
                else
                    pdfFont = new PdfTrueTypeFont(Owner, font);
                //pdfFont.Document = _document;
                Debug.Assert(pdfFont.Owner == Owner);
                _fonts[selector] = pdfFont;
            }
            return pdfFont;
        }

#if true
        /// <summary>
        /// Gets a PdfFont from a font program. If no PdfFont already exists, a new one is created.
        /// </summary>
        public PdfFont GetFont(string idName, byte[] fontData)
        {
            Debug.Assert(false);
            //FontSelector selector = new FontSelector(idName);
            string selector = null; // ComputeKey(font); //new FontSelector(font);
            PdfFont pdfFont;
            if (!_fonts.TryGetValue(selector, out pdfFont))
            {
                //if (font.Unicode)
                pdfFont = new PdfType0Font(Owner, idName, fontData, false);
                //else
                //  pdfFont = new PdfTrueTypeFont(_owner, font);
                //pdfFont.Document = _document;
                Debug.Assert(pdfFont.Owner == Owner);
                _fonts[selector] = pdfFont;
            }
            return pdfFont;
        }
#endif

        /// <summary>
        /// Tries to gets a PdfFont from the font dictionary.
        /// Returns null if no such PdfFont exists.
        /// </summary>
        public PdfFont TryGetFont(string idName)
        {
            Debug.Assert(false);
            //FontSelector selector = new FontSelector(idName);
            string selector = null;
            PdfFont pdfFont;
            _fonts.TryGetValue(selector, out pdfFont);
            return pdfFont;
        }

        internal static string ComputeKey(XFont font)
        {
            XGlyphTypeface glyphTypeface = font.GlyphTypeface;
            string key = glyphTypeface.Fontface.FullFaceName.ToLowerInvariant() +
                (glyphTypeface.IsBold ? "/b" : "") + (glyphTypeface.IsItalic ? "/i" : "") + font.Unicode;
            return key;
        }

        /// <summary>
        /// Map from PdfFontSelector to PdfFont.
        /// </summary>
        readonly Dictionary<string, PdfFont> _fonts = new Dictionary<string, PdfFont>();

        public void PrepareForSave()
        {
            foreach (PdfFont font in _fonts.Values)
                font.PrepareForSave();
        }
    }
}
