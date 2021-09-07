#define GDI


using System;
using System.Collections;
using System.Globalization;
using System.Text;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Internal;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf
{
    /// <summary>
    /// Represents text that is written 'as it is' into the PDF stream. This class can lead to invalid PDF files.
    /// E.g. strings in a literal are not encrypted when the document is saved with a password.
    /// </summary>
    public sealed class PdfLiteral : PdfItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfLiteral"/> class.
        /// </summary>
        public PdfLiteral()
        { }

        /// <summary>
        /// Initializes a new instance with the specified string.
        /// </summary>
        public PdfLiteral(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Initializes a new instance with the culture invariant formatted specified arguments.
        /// </summary>
        public PdfLiteral(string format, params object[] args)
        {
            _value = PdfEncoders.Format(format, args);
        }

        /// <summary>
        /// Creates a literal from an XMatrix
        /// </summary>
        public static PdfLiteral FromMatrix(XMatrix matrix)
        {
            return new PdfLiteral("[" + PdfEncoders.ToString(matrix) + "]");
        }

        /// <summary>
        /// Gets the value as litaral string.
        /// </summary>
        public string Value
        {
            // This class must behave like a value type. Therefore it cannot be changed (like System.String).
            get { return _value; }
        }
        readonly string _value = String.Empty;

        /// <summary>
        /// Returns a string that represents the current value.
        /// </summary>
        public override string ToString()
        {
            return _value;
        }

        internal override void WriteObject(PdfWriter writer)
        {
            writer.Write(this);
        }
    }
}
