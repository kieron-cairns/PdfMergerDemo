#define GDI


namespace PdfSharp.Pdf
{
    /// <summary>
    /// This class is intended for empira internal use only and may change or drop in future releases.
    /// </summary>
    public class PdfCustomValue : PdfDictionary
    {
        /// <summary>
        /// This function is intended for empira internal use only.
        /// </summary>
        public PdfCustomValue()
        {
            CreateStream(new byte[] { });
        }

        /// <summary>
        /// This function is intended for empira internal use only.
        /// </summary>
        public PdfCustomValue(byte[] bytes)
        {
            CreateStream(bytes);
        }

        internal PdfCustomValue(PdfDocument document)
            : base(document)
        {
            CreateStream(new byte[] { });
        }

        internal PdfCustomValue(PdfDictionary dict)
            : base(dict)
        {
            // TODO: uncompress stream
        }

        /// <summary>
        /// This property is intended for empira internal use only.
        /// </summary>
        public PdfCustomValueCompressionMode CompressionMode;

        /// <summary>
        /// This property is intended for empira internal use only.
        /// </summary>
        public byte[] Value
        {
            get { return Stream.Value; }
            set { Stream.Value = value; }
        }
    }
}
