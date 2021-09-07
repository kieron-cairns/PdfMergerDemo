#define GDI


using System;
using System.Collections.Generic;
using System.Text;

namespace PdfSharp.Drawing
{
    /// <summary>
    /// Backward compatibility.
    /// </summary>
    [Flags]
    internal enum XGdiFontStyle  // Same values as System.Drawing.FontStyle.
    {
        // Must be identical to both:
        // System.Drawing.FontStyle and
        // PdfSharp.Drawing.FontStyle

        /// <summary>
        /// Normal text.
        /// </summary>
        Regular = 0,

        /// <summary>
        /// Bold text.
        /// </summary>
        Bold = 1,

        /// <summary>
        /// Italic text.
        /// </summary>
        Italic = 2,

        /// <summary>
        /// Bold and italic text. 
        /// </summary>
        BoldItalic = 3,

        /// <summary>
        /// Underlined text.
        /// </summary>
        Underline = 4,

        /// <summary>
        /// Text with a line through the middle.
        /// </summary>
        Strikeout = 8,
    }
}
