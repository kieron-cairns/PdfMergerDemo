#define GDI


using System;

namespace PdfSharp.Pdf.Advanced
{
    /// <summary>
    /// Represents a PDF page object.
    /// </summary>
    internal class PdfPageInheritableObjects : PdfDictionary
    {
        public PdfPageInheritableObjects()
        { }

        // TODO Inheritable Resources not yet supported

        /// <summary>
        /// 
        /// </summary>
        public PdfRectangle MediaBox
        {
            get { return _mediaBox; }
            set { _mediaBox = value; }
        }
        PdfRectangle _mediaBox;

        public PdfRectangle CropBox
        {
            get { return _cropBox; }
            set { _cropBox = value; }
        }
        PdfRectangle _cropBox;

        public int Rotate
        {
            get { return _rotate; }
            set
            {
                if (value % 90 != 0)
                    throw new ArgumentException("The value must be a multiple of 90.", nameof(value));
                _rotate = value;
            }
        }
        int _rotate;
    }
}
