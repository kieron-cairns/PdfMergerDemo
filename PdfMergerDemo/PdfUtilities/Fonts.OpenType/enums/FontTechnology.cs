#define GDI


namespace PdfSharp.Fonts.OpenType
{
    /// <summary>
    /// Identifies the technology of an OpenType font file.
    /// </summary>
    enum FontTechnology
    {
        /// <summary>
        /// Font is Adobe Postscript font in CFF.
        /// </summary>
        PostscriptOutlines,

        /// <summary>
        /// Font is a TrueType font.
        /// </summary>
        TrueTypeOutlines,

        /// <summary>
        /// Font is a TrueType font collection.
        /// </summary>
        TrueTypeCollection
    }
}
