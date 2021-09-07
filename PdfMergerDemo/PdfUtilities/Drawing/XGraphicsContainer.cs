#define GDI


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
    /// Represents the internal state of an XGraphics object.
    /// </summary>
    public sealed class XGraphicsContainer
    {
#if GDI
        internal XGraphicsContainer(GraphicsState state)
        {
            GdiState = state;
        }
        internal GraphicsState GdiState;
#endif
#if WPF
        internal XGraphicsContainer()
        { }
#endif
        internal InternalGraphicsState InternalState;
    }
}
