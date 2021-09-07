#define GDI


using System;

namespace PdfSharp.Pdf
{
    /// <summary>
    /// Specifies the encoding schema used for an XFont when converted into PDF.
    /// </summary>
    public enum PdfFontEncoding
    {
        // TABLE

        /// <summary>
        /// Cause a font to use Windows-1252 encoding to encode text rendered with this font.
        /// Same as Windows1252 encoding.
        /// </summary>
        WinAnsi = 0,

        ///// <summary>
        ///// Cause a font to use Windows-1252 (aka WinAnsi) encoding to encode text rendered with this font.
        ///// </summary>
        //Windows1252 = 0,

        /// <summary>
        /// Cause a font to use Unicode encoding to encode text rendered with this font.
        /// </summary>
        Unicode = 1,

        /// <summary>
        /// Unicode encoding.
        /// </summary>
        [Obsolete("Use WinAnsi or Unicode")]
        Automatic = 1,  // Force Unicode when used.

        // Implementation note: PdfFontEncoding uses incorrect terms.
        // WinAnsi correspond to WinAnsiEncoding, while Unicode uses glyph indices.
        // Furthermre the term WinAnsi is an oxymoron.
        // Reference: TABLE  D.1 Latin-text encodings / Page 996
    }
}
