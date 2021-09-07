#define GDI


namespace PdfSharp.Pdf.Security
{
    /// <summary>
    /// Specifies the security level of the PDF document.
    /// </summary>
    public enum PdfDocumentSecurityLevel
    {
        /// <summary>
        /// Document is not protected.
        /// </summary>
        None,

        /// <summary>
        /// Document is protected with 40-bit security. This option is for compatibility with 
        /// Acrobat 3 and 4 only. Use Encrypted128Bit whenever possible.
        /// </summary>
        Encrypted40Bit,

        /// <summary>
        /// Document is protected with 128-bit security.
        /// </summary>
        Encrypted128Bit,
    }
}
