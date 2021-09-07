#define GDI


#if CORE
#endif
#if GDI
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
#endif
#if WPF
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
#endif
#if NETFX_CORE
using Windows.UI.Xaml.Media.Imaging;
#endif

namespace PdfSharp.Drawing
{
    /// <summary>
    /// Provides functionality to load a bitmap image encoded in a specific format.
    /// </summary>
    public class XBitmapDecoder
    {
        internal XBitmapDecoder()
        { }

        /// <summary>
        /// Gets a new instance of the PNG image decoder.
        /// </summary>
        public static XBitmapDecoder GetPngDecoder()
        {
            return new XPngBitmapDecoder();
        }
    }

    internal sealed class XPngBitmapDecoder : XBitmapDecoder
    {
        internal XPngBitmapDecoder()
        { }
    }
}
