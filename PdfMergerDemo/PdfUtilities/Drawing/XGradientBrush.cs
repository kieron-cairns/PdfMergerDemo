#define GDI


using System;
using System.ComponentModel;
using PdfSharp.Internal;
#if GDI
using System.Drawing;
using System.Drawing.Drawing2D;
using GdiLinearGradientBrush =System.Drawing.Drawing2D.LinearGradientBrush;
#endif
#if WPF
using System.Windows;
using System.Windows.Media;
using SysPoint = System.Windows.Point;
using SysSize = System.Windows.Size;
using SysRect = System.Windows.Rect;
using WpfBrush = System.Windows.Media.Brush;
#endif
#if UWP
using Windows.UI;
using Windows.UI.Xaml.Media;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Brushes;
#endif

namespace PdfSharp.Drawing
{
    /// <summary>
    /// Defines a Brush with a linear gradient.
    /// </summary>
    public abstract class XGradientBrush : XBrush
    {
        /// <summary>
        /// Gets or sets a value indicating whether or not to extend the gradient beyond its bounds.
        /// </summary>
        public bool ExtendLeft
        {
            get { return _extendLeft; }
            set { _extendLeft = value; }
        }
        internal bool _extendLeft;

        /// <summary>
        /// Gets or sets a value indicating whether or not to extend the gradient beyond its bounds.
        /// </summary>
        public bool ExtendRight
        {
            get { return _extendRight; }
            set { _extendRight = value; }
        }
        internal bool _extendRight;
    }
}
