#define GDI


using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
    /// <summary>
    /// Represents an indirect boolean value. This type is not used by PDFsharp. If it is imported from
    /// an external PDF file, the value is converted into a direct object.
    /// </summary>
    [DebuggerDisplay("({Value})")]
    public sealed class PdfBooleanObject : PdfObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfBooleanObject"/> class.
        /// </summary>
        public PdfBooleanObject()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfBooleanObject"/> class.
        /// </summary>
        public PdfBooleanObject(bool value)
        {
            _value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfBooleanObject"/> class.
        /// </summary>
        public PdfBooleanObject(PdfDocument document, bool value)
            : base(document)
        {
            _value = value;
        }

        /// <summary>
        /// Gets the value of this instance as boolean value.
        /// </summary>
        public bool Value
        {
            get { return _value; }
            //set { _value = value; }
        }

        readonly bool _value;

        /// <summary>
        /// Returns "false" or "true".
        /// </summary>
        public override string ToString()
        {
            return _value ? bool.TrueString : bool.FalseString;
        }

        /// <summary>
        /// Writes the keyword �false� or �true�.
        /// </summary>
        internal override void WriteObject(PdfWriter writer)
        {
            writer.WriteBeginObject(this);
            writer.Write(_value);
            writer.WriteEndObject();
        }
    }
}
