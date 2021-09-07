#define GDI


namespace PdfSharp.Drawing
{
    /// <summary>
    /// Type of the path data.
    /// </summary>
    internal enum XGraphicsPathItemType
    {
        Lines,
        Beziers,
        Curve,
        Arc,
        Rectangle,
        RoundedRectangle,
        Ellipse,
        Polygon,
        CloseFigure,
        StartFigure,
    }
}
