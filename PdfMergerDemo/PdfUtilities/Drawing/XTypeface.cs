#define GDI


#if GDI
using System.Drawing;
using System.Drawing.Drawing2D;
#endif
#if WPF
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
#endif

namespace PdfSharp.Drawing
{
#if true_  // Not yet used
    /// <summary>
    /// no: Specifies a physical font face that corresponds to a font file on the disk or in memory.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay}")]
    internal class XTypeface_not_yet_used
    {
        public XTypeface_not_yet_used(XFontFamily family, XFontStyle style)
        {
            _family = family;
            _style = style;
        }

        public XFontFamily Family
        {
            get { return _family; }
        }
        XFontFamily _family;

        public XFontStyle Style
        {
            get { return _style; }
        }
        XFontStyle _style;

        public bool TryGetGlyphTypeface(out XGlyphTypeface glyphTypeface)
        {
            glyphTypeface = null;
            return false;
        }

        /// <summary>
        /// Gets the DebuggerDisplayAttribute text.
        /// </summary>
        // ReSharper disable UnusedMember.Local
        string DebuggerDisplay
        // ReSharper restore UnusedMember.Local
        {
            get { return string.Format(CultureInfo.InvariantCulture, "XTypeface"); }
        }
    }
#endif
}
