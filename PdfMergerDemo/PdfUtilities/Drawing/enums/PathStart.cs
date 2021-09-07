#define GDI


// ReSharper disable InconsistentNaming

namespace PdfSharp.Drawing
{
    /// <summary>
    /// Indicates how to handle the first point of a path.
    /// </summary>
    internal enum PathStart
    {
        /// <summary>
        /// Set the current position to the first point.
        /// </summary>
        MoveTo1st,

        /// <summary>
        /// Draws a line to the first point.
        /// </summary>
        LineTo1st,

        /// <summary>
        /// Ignores the first point.
        /// </summary>
        Ignore1st,
    }
}
