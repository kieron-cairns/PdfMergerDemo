#define GDI


using System.Diagnostics;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf
{
    /// <summary>
    /// Represents trim margins added to the page.
    /// </summary>
    [DebuggerDisplay("(Left={_left.Millimeter}mm, Right={_right.Millimeter}mm, Top={_top.Millimeter}mm, Bottom={_bottom.Millimeter}mm)")]
    public sealed class TrimMargins
    {
        ///// <summary>
        ///// Clones this instance.
        ///// </summary>
        //public TrimMargins Clone()
        //{
        //  TrimMargins trimMargins = new TrimMargins();
        //  trimMargins.left = left;
        //  trimMargins.top = top;
        //  trimMargins.right = right;
        //  trimMargins.bottom = bottom;
        //  return trimMargins;
        //}

        /// <summary>
        /// Sets all four crop margins simultaneously.
        /// </summary>
        public XUnit All
        {
            set
            {
                _left = value;
                _right = value;
                _top = value;
                _bottom = value;
            }
        }

        /// <summary>
        /// Gets or sets the left crop margin.
        /// </summary>
        public XUnit Left
        {
            get { return _left; }
            set { _left = value; }
        }
        XUnit _left;

        /// <summary>
        /// Gets or sets the right crop margin.
        /// </summary>
        public XUnit Right
        {
            get { return _right; }
            set { _right = value; }
        }
        XUnit _right;

        /// <summary>
        /// Gets or sets the top crop margin.
        /// </summary>
        public XUnit Top
        {
            get { return _top; }
            set { _top = value; }
        }
        XUnit _top;

        /// <summary>
        /// Gets or sets the bottom crop margin.
        /// </summary>
        public XUnit Bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }
        XUnit _bottom;

        /// <summary>
        /// Gets a value indicating whether this instance has at least one margin with a value other than zero.
        /// </summary>
        public bool AreSet
        {
            get { return _left.Value != 0 || _right.Value != 0 || _top.Value != 0 || _bottom.Value != 0; }
        }
    }
}
