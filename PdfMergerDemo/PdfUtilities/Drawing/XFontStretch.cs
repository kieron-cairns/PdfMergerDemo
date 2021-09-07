#define GDI


namespace PdfSharp.Drawing
{
#if PDFSHARP20
    enum FontStretchValues
    {
        UltraCondensed = 1,
        ExtraCondensed = 2,
        Condensed = 3,
        SemiCondensed = 4,
        Normal = 5,
        SemiExpanded = 6,
        Expanded = 7,
        ExtraExpanded = 8,
        UltraExpanded = 9,
    }

    /// <summary>
    /// NYI. Reserved for future extensions of PDFsharp.
    /// </summary>
    // [DebuggerDisplay("'{Name}', {Size}")]
    public class XFontStretch
    { }
#endif
}
