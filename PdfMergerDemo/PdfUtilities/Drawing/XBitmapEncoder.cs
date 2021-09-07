#define GDI


using System;
using System.Diagnostics;
using System.IO;
using PdfSharp.Internal;
#if CORE
#endif
#if CORE_WITH_GDI
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
    /// Provides functionality to save a bitmap image in a specific format.
    /// </summary>
    public abstract class XBitmapEncoder
    {
        internal XBitmapEncoder()
        {
            // Prevent external deriving.
        }

        /// <summary>
        /// Gets a new instance of the PNG image encoder.
        /// </summary>
        public static XBitmapEncoder GetPngEncoder()
        {
            return new XPngBitmapEncoder();
        }

        /// <summary>
        /// Gets or sets the bitmap source to be encoded.
        /// </summary>
        public XBitmapSource Source
        {
            get { return _source; }
            set { _source = value; }
        }
        XBitmapSource _source;

        /// <summary>
        /// When overridden in a derived class saves the image on the specified stream
        /// in the respective format.
        /// </summary>
        public abstract void Save(Stream stream);
    }

    internal sealed class XPngBitmapEncoder : XBitmapEncoder
    {
        internal XPngBitmapEncoder()
        { }

        /// <summary>
        /// Saves the image on the specified stream in PNG format.
        /// </summary>
        public override void Save(Stream stream)
        {
            if (Source == null)
                throw new InvalidOperationException("No image source.");
#if CORE_WITH_GDI || GDI
            if (Source.AssociatedGraphics != null)
            {
                Source.DisassociateWithGraphics();
                Debug.Assert(Source.AssociatedGraphics == null);
            }
            try
            {
                Lock.EnterGdiPlus();
                Source._gdiImage.Save(stream, ImageFormat.Png);
            }
            finally { Lock.ExitGdiPlus(); }
#endif
#if WPF
            DiagnosticsHelper.ThrowNotImplementedException("Save...");
#endif
        }
    }
}
