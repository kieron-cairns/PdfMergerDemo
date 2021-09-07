#define GDI


namespace PdfSharp.Pdf.Annotations
{
    /// <summary>
    /// Represents a generic annotation. Used for annotation dictionaries unknown to PDFsharp.
    /// </summary>
    internal sealed class PdfGenericAnnotation : PdfAnnotation
    {
        //DMH 6/7/06
        //Make this public so we can use it in PdfAnnotations to
        //get the Meta data from existings annotations.
        public PdfGenericAnnotation(PdfDictionary dict)
            : base(dict)
        { }

        /// <summary>
        /// Predefined keys of this dictionary.
        /// </summary>
        internal new class Keys : PdfAnnotation.Keys
        {
            public static DictionaryMeta Meta
            {
                get { return _meta ?? (_meta = CreateMeta(typeof(Keys))); }
            }
            static DictionaryMeta _meta;
        }

        /// <summary>
        /// Gets the KeysMeta of this dictionary type.
        /// </summary>
        internal override DictionaryMeta Meta
        {
            get { return Keys.Meta; }
        }
    }
}
