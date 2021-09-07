#define GDI


namespace PdfSharp.Pdf
{
    /// <summary>
    /// Specifies what color model is used in a PDF document.
    /// </summary>
    public enum PdfColorMode
    {
        /// <summary>
        /// All color values are written as specified in the XColor objects they come from.
        /// </summary>
        Undefined,

        /// <summary>
        /// All colors are converted to RGB.
        /// </summary>
        Rgb,

        /// <summary>
        /// All colors are converted to CMYK.
        /// </summary>
        Cmyk,
    }
}