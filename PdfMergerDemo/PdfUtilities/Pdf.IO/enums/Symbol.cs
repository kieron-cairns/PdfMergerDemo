#define GDI


namespace PdfSharp.Pdf.IO
{
    /// <summary>
    /// Terminal symbols recognized by lexer.
    /// </summary>
    public enum Symbol
    {
#pragma warning disable 1591
        None,
        Comment, Null, Integer, UInteger, Real, Boolean, String, HexString, UnicodeString, UnicodeHexString,
        Name, Keyword,
        BeginStream, EndStream,
        BeginArray, EndArray,
        BeginDictionary, EndDictionary,
        Obj, EndObj, R, XRef, Trailer, StartXRef, Eof,
#pragma warning restore 1591
    }
}
