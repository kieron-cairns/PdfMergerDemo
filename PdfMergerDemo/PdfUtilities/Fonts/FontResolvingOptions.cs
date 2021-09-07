#define GDI


#if GDI
using System.Drawing;
using System.Drawing.Text;
#endif
#if WPF
using System.Windows.Media;
#endif
using PdfSharp.Drawing;

namespace PdfSharp.Fonts
{
    /// <summary>
    /// Parameters that affect font selection.
    /// </summary>
    class FontResolvingOptions
    {
        public FontResolvingOptions(XFontStyle fontStyle)
        {
            FontStyle = fontStyle;
        }

        public FontResolvingOptions(XFontStyle fontStyle, XStyleSimulations styleSimulations)
        {
            FontStyle = fontStyle;
            OverrideStyleSimulations = true;
            StyleSimulations = styleSimulations;
        }

        public bool IsBold
        {
            get { return (FontStyle & XFontStyle.Bold) == XFontStyle.Bold; }
        }

        public bool IsItalic
        {
            get { return (FontStyle & XFontStyle.Italic) == XFontStyle.Italic; }
        }

        public bool IsBoldItalic
        {
            get { return (FontStyle & XFontStyle.BoldItalic) == XFontStyle.BoldItalic; }
        }

        public bool MustSimulateBold
        {
            get { return (StyleSimulations & XStyleSimulations.BoldSimulation) == XStyleSimulations.BoldSimulation; }
        }

        public bool MustSimulateItalic
        {
            get { return (StyleSimulations & XStyleSimulations.ItalicSimulation) == XStyleSimulations.ItalicSimulation; }
        }

        public XFontStyle FontStyle;

        public bool OverrideStyleSimulations;

        public XStyleSimulations StyleSimulations;
    }
}
