#define GDI


namespace PdfSharp.Pdf
{
    /// <summary>
    /// Base class for indirect number values (not yet used, maybe superfluous).
    /// </summary>
    public abstract class PdfNumberObject : PdfObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfNumberObject"/> class.
        /// </summary>
        protected PdfNumberObject()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfNumberObject"/> class.
        /// </summary>
        /// <param name="document">The document.</param>
        protected PdfNumberObject(PdfDocument document)
            : base(document)
        { }
    }
}
