#define GDI


#if CORE
#endif

using System.Diagnostics;
using PdfSharp.Internal;

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

// WPFHACK
#pragma warning disable 0169
#pragma warning disable 0649

namespace PdfSharp.Drawing
{
    /// <summary>
    /// Defines an abstract base class for pixel based images.
    /// </summary>
    public abstract class XBitmapSource : XImage
    {
        // TODO: Move code from XImage to this class.

        /// <summary>
        /// Gets the width of the image in pixels.
        /// </summary>
        public override int PixelWidth
        {
            get
            {
#if (CORE_WITH_GDI || GDI) && !WPF
                try
                {
                    Lock.EnterGdiPlus();
                    return _gdiImage.Width;
                }
                finally { Lock.ExitGdiPlus(); }
#endif
#if GDI && WPF
                int gdiWidth = _gdiImage.Width;
                int wpfWidth = _wpfImage.PixelWidth;
                Debug.Assert(gdiWidth == wpfWidth);
                return wpfWidth;
#endif
#if WPF && !GDI
                return _wpfImage.PixelWidth;
#endif
#if NETFX_CORE || UWP || DNC10
                return _wrtImage.PixelWidth;
#endif
            }
        }

        /// <summary>
        /// Gets the height of the image in pixels.
        /// </summary>
        public override int PixelHeight
        {
            get
            {
#if (CORE_WITH_GDI || GDI) && !WPF
                try
                {
                    Lock.EnterGdiPlus();
                    return _gdiImage.Height;
                }
                finally { Lock.ExitGdiPlus(); }
#endif
#if GDI && WPF
                int gdiHeight = _gdiImage.Height;
                int wpfHeight = _wpfImage.PixelHeight;
                Debug.Assert(gdiHeight == wpfHeight);
                return wpfHeight;
#endif
#if WPF && !GDI
                return _wpfImage.PixelHeight;
#endif
#if NETFX_CORE || UWP || DNC10
                return _wrtImage.PixelHeight;
#endif
            }
        }
    }
}
