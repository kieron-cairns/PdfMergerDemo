#define GDI


using System;
#if GDI
using System.Drawing;
using System.Drawing.Drawing2D;
#endif
#if WPF
using System.Windows.Media;
#endif
using PdfSharp.Pdf;

namespace PdfSharp.Drawing
{
    /// <summary>
    /// Specifies details about how the font is used in PDF creation.
    /// </summary>
    public class XPdfFontOptions
    {
        internal XPdfFontOptions() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="XPdfFontOptions"/> class.
        /// </summary>
        [Obsolete("Must not specify an embedding option anymore.")]
        public XPdfFontOptions(PdfFontEncoding encoding, PdfFontEmbedding embedding)
        {
            _fontEncoding = encoding;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XPdfFontOptions"/> class.
        /// </summary>
        public XPdfFontOptions(PdfFontEncoding encoding)
        {
            _fontEncoding = encoding;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XPdfFontOptions"/> class.
        /// </summary>
        [Obsolete("Must not specify an embedding option anymore.")]
        public XPdfFontOptions(PdfFontEmbedding embedding)
        {
            _fontEncoding = PdfFontEncoding.WinAnsi;
        }

        /// <summary>
        /// Gets a value indicating the font embedding.
        /// </summary>
        public PdfFontEmbedding FontEmbedding
        {
            get { return PdfFontEmbedding.Always; }
        }

        /// <summary>
        /// Gets a value indicating how the font is encoded.
        /// </summary>
        public PdfFontEncoding FontEncoding
        {
            get { return _fontEncoding; }
        }
        readonly PdfFontEncoding _fontEncoding;

        /// <summary>
        /// Gets the default options with WinAnsi encoding and always font embedding.
        /// </summary>
        public static XPdfFontOptions WinAnsiDefault
        {
            get { return new XPdfFontOptions(PdfFontEncoding.WinAnsi); }
        }

        /// <summary>
        /// Gets the default options with Unicode encoding and always font embedding.
        /// </summary>
        public static XPdfFontOptions UnicodeDefault
        {
            get { return new XPdfFontOptions(PdfFontEncoding.Unicode); }
        }
    }
}
