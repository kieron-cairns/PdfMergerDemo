#define GDI


#if CORE || GDI
using System.Drawing;
using GdiFont = System.Drawing.Font;

#endif
#if WPF
using System.Windows.Media;
using WpfFontFamily = System.Windows.Media.FontFamily;
using WpfTypeface = System.Windows.Media.Typeface;
using WpfGlyphTypeface = System.Windows.Media.GlyphTypeface;
#endif

namespace PdfSharp.Fonts
{
    /// <summary>
    /// Represents a font resolver info created by the platform font resolver.
    /// </summary>
    internal class PlatformFontResolverInfo : FontResolverInfo
    {
#if CORE || GDI
        public PlatformFontResolverInfo(string faceName, bool mustSimulateBold, bool mustSimulateItalic, GdiFont gdiFont)
            : base(faceName, mustSimulateBold, mustSimulateItalic)
        {
            _gdiFont = gdiFont;
        }
#endif
#if WPF
        public PlatformFontResolverInfo(string faceName, bool mustSimulateBold, bool mustSimulateItalic, WpfFontFamily wpfFontFamily,
            WpfTypeface wpfTypeface, WpfGlyphTypeface wpfGlyphTypeface)
            : base(faceName, mustSimulateBold, mustSimulateItalic)
        {
            _wpfFontFamily = wpfFontFamily;
            _wpfTypeface = wpfTypeface;
            _wpfGlyphTypeface = wpfGlyphTypeface;
        }
#endif

#if CORE || GDI
        public Font GdiFont
        {
            get { return _gdiFont; }
        }
        readonly Font _gdiFont;
#endif
#if WPF
        public WpfFontFamily WpfFontFamily
        {
            get { return _wpfFontFamily; }
        }
        readonly WpfFontFamily _wpfFontFamily;

        public WpfTypeface WpfTypeface
        {
            get { return _wpfTypeface; }
        }
        readonly WpfTypeface _wpfTypeface;

        public WpfGlyphTypeface WpfGlyphTypeface
        {
            get { return _wpfGlyphTypeface; }
        }
        readonly WpfGlyphTypeface _wpfGlyphTypeface;
#endif
#if NETFX_CORE || UWP || DNC10
        public PlatformFontResolverInfo(string faceName, bool mustSimulateBold, bool mustSimulateItalic)
            : base(faceName, mustSimulateBold, mustSimulateItalic)
        {
            //_gdiFont = gdiFont;
        }
#endif
    }
}
