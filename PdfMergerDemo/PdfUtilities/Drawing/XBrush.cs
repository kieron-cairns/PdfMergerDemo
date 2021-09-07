#define GDI


#if GDI
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
#endif
#if WPF
using System.Windows.Media;
#endif
#if UWP
using Microsoft.Graphics.Canvas.Brushes;
using UwpColor = Windows.UI.Color;
#endif

namespace PdfSharp.Drawing
{
    /// <summary>
    /// Classes derived from this abstract base class define objects used to fill the 
    /// interiors of paths.
    /// </summary>
    public abstract class XBrush
    {
#if GDI
        internal abstract System.Drawing.Brush RealizeGdiBrush();

#if UseGdiObjects
        /// <summary>
        /// Converts from a System.Drawing.Brush.
        /// </summary>
        public static implicit operator XBrush(Brush brush)
        {
            XBrush xbrush;
            SolidBrush solidBrush;
            LinearGradientBrush lgBrush;
            if ((solidBrush = brush as SolidBrush) != null)
            {
                xbrush = new XSolidBrush(solidBrush.Color);
            }
            else if ((lgBrush = brush as LinearGradientBrush) != null)
            {
                // TODO: xbrush = new LinearGradientBrush(lgBrush.Rectangle, lgBrush.co(solidBrush.Color);
                throw new NotImplementedException("Brush type not yet supported by PDFsharp.");
            }
            else
            {
                throw new NotImplementedException("Brush type not supported by PDFsharp.");
            }
            return xbrush;
        }
#endif
#endif
#if WPF
        internal abstract System.Windows.Media.Brush RealizeWpfBrush();
#endif
#if UWP
        internal abstract ICanvasBrush RealizeCanvasBrush();
#endif
    }
}
