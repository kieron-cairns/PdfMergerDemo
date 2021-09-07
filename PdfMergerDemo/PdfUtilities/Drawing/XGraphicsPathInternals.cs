#define GDI


#if GDI
using System.Drawing;
using System.Drawing.Drawing2D;
#endif
#if WPF
using System.Windows;
using System.Windows.Media;
#endif
#if NETFX_CORE
using Windows.UI.Xaml.Media;
#endif

namespace PdfSharp.Drawing
{
    /// <summary>
    /// Provides access to the internal data structures of XGraphicsPath.
    /// This class prevents the public interface from pollution with internal functions.
    /// </summary>
    public sealed class XGraphicsPathInternals
    {
        internal XGraphicsPathInternals(XGraphicsPath path)
        {
            _path = path;
        }
        XGraphicsPath _path;

#if GDI
        /// <summary>
        /// Gets the underlying GDI+ path object.
        /// </summary>
        public GraphicsPath GdiPath
        {
            get { return _path._gdipPath; }
        }
#endif

#if WPF || NETFX_CORE
        /// <summary>
        /// Gets the underlying WPF path geometry object.
        /// </summary>
        public PathGeometry WpfPath
        {
            get { return _path._pathGeometry; }
        }
#endif
    }
}