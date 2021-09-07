#define GDI


namespace PdfSharp.Drawing.Layout
{
    /// <summary>
    /// Specifies the alignment of a paragraph.
    /// </summary>
    public enum XParagraphAlignment
    {
        /// <summary>
        /// Default alignment, typically left alignment.
        /// </summary>
        Default,

        /// <summary>
        /// The paragraph is rendered left aligned.
        /// </summary>
        Left,

        /// <summary>
        /// The paragraph is rendered centered.
        /// </summary>
        Center,

        /// <summary>
        /// The paragraph is rendered right aligned.
        /// </summary>
        Right,

        /// <summary>
        /// The paragraph is rendered justified.
        /// </summary>
        Justify,
    }
}
