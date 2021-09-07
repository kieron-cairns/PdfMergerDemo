#define GDI


// ReSharper disable InconsistentNaming

namespace PdfSharp.Drawing
{
    ///<summary>
    /// Determines whether rendering based on GDI+ or WPF.
    /// For internal use in hybrid build only only.
    /// </summary>
    enum XGraphicTargetContext
    {
        // NETFX_CORE_TODO
        NONE = 0,

        /// <summary>
        /// Rendering does not depent on a particular technology.
        /// </summary>
        CORE = 1,

        /// <summary>
        /// Renders using GDI+.
        /// </summary>
        GDI = 2,

        /// <summary>
        /// Renders using WPF (including Silverlight).
        /// </summary>
        WPF = 3,

        /// <summary>
        /// Universal Windows Platform.
        /// </summary>
        UWP = 10,
    }
}
