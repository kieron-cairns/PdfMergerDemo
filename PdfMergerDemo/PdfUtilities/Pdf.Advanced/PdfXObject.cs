#define GDI


namespace PdfSharp.Pdf.Advanced
{
    /// <summary>
    /// Base class for all PDF external objects.
    /// </summary>
    public abstract class PdfXObject : PdfDictionary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfXObject"/> class.
        /// </summary>
        /// <param name="document">The document that owns the object.</param>
        protected PdfXObject(PdfDocument document)
            : base(document)
        { }

        /// <summary>
        /// Predefined keys of this dictionary.
        /// </summary>
        public class Keys : PdfStream.Keys
        { }
    }
}
