#define GDI


#if CORE
#endif
#if CORE
#endif
#if GDI
using System.Drawing;
using System.Drawing.Drawing2D;
#endif
#if WPF
using System.Windows.Media;
#endif

namespace PdfSharp.Drawing
{
    /// <summary>
    /// Converts XGraphics enums to GDI+ enums.
    /// </summary>
    internal static class XConvert
    {
#if GDI
//#if UseGdiObjects
        /// <summary>
        /// Converts XLineJoin to LineJoin.
        /// </summary>
        public static LineJoin ToLineJoin(XLineJoin lineJoin)
        {
            return GdiLineJoin[(int)lineJoin];
        }
        static readonly LineJoin[] GdiLineJoin = new LineJoin[] { LineJoin.Miter, LineJoin.Round, LineJoin.Bevel };
//#endif
#endif

#if GDI
//#if UseGdiObjects
        /// <summary>
        /// Converts XLineCap to LineCap.
        /// </summary>
        public static LineCap ToLineCap(XLineCap lineCap)
        {
            return _gdiLineCap[(int)lineCap];
        }
        static readonly LineCap[] _gdiLineCap = new LineCap[] { LineCap.Flat, LineCap.Round, LineCap.Square };
        //#endif
#endif

#if WPF
        /// <summary>
        /// Converts XLineJoin to PenLineJoin.
        /// </summary>
        public static PenLineJoin ToPenLineJoin(XLineJoin lineJoin)
        {
            return WpfLineJoin[(int)lineJoin];
        }
        static readonly PenLineJoin[] WpfLineJoin = new PenLineJoin[] { PenLineJoin.Miter, PenLineJoin.Round, PenLineJoin.Bevel };
#endif

#if WPF
        /// <summary>
        /// Converts XLineCap to PenLineCap.
        /// </summary>
        public static PenLineCap ToPenLineCap(XLineCap lineCap)
        {
            return WpfLineCap[(int)lineCap];
        }
        static readonly PenLineCap[] WpfLineCap = new PenLineCap[] { PenLineCap.Flat, PenLineCap.Round, PenLineCap.Square };
#endif
    }
}