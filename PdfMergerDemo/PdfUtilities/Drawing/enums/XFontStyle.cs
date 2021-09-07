#define GDI


using System;

namespace PdfSharp.Drawing
{
    /// <summary>
    /// Specifies style information applied to text.
    /// </summary>
    [Flags]
    public enum XFontStyle  // Same values as System.Drawing.FontStyle.
    {
        /// <summary>
        /// Normal text.
        /// </summary>
        Regular = XGdiFontStyle.Regular,

        /// <summary>
        /// Bold text.
        /// </summary>
        Bold = XGdiFontStyle.Bold,

        /// <summary>
        /// Italic text.
        /// </summary>
        Italic = XGdiFontStyle.Italic,

        /// <summary>
        /// Bold and italic text. 
        /// </summary>
        BoldItalic = XGdiFontStyle.BoldItalic,

        /// <summary>
        /// Underlined text.
        /// </summary>
        Underline = XGdiFontStyle.Underline,

        /// <summary>
        /// Text with a line through the middle.
        /// </summary>
        Strikeout = XGdiFontStyle.Strikeout,

        // Additional flags:
        // BoldSimulation
        // ItalicSimulation // It is not ObliqueSimulation, because oblique is what is what you get and this simulates italic.
    }
}
