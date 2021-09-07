#define GDI


using System;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
    /// <summary>
    /// The base class of all PDF objects and simple PDF types.
    /// </summary>
    public abstract class PdfItem : ICloneable
    {
        // All simple types (i.e. derived from PdfItem but not from PdfObject) must be immutable.

        object ICloneable.Clone()
        {
            return Copy();
        }

        /// <summary>
        /// Creates a copy of this object.
        /// </summary>
        public PdfItem Clone()
        {
            return (PdfItem)Copy();
        }

        /// <summary>
        /// Implements the copy mechanism. Must be overridden in derived classes.
        /// </summary>
        protected virtual object Copy()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// When overridden in a derived class, appends a raw string representation of this object
        /// to the specified PdfWriter.
        /// </summary>
        internal abstract void WriteObject(PdfWriter writer);
    }
}
