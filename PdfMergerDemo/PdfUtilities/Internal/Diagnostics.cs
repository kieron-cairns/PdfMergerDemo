#define GDI


using System;
using System.Globalization;
using PdfSharp.Pdf.Content;
using PdfSharp.Pdf.IO;

#if GDI
using System.Drawing;
#endif
#if WPF
using System.Windows;
#endif

namespace PdfSharp.Internal
{
    enum NotImplementedBehaviour
    {
        DoNothing, Log, Throw
    }

    /// <summary>
    /// A bunch of internal helper functions.
    /// </summary>
    internal static class Diagnostics
    {
        public static NotImplementedBehaviour NotImplementedBehaviour
        {
            get { return _notImplementedBehaviour; }
            set { _notImplementedBehaviour = value; }
        }
        static NotImplementedBehaviour _notImplementedBehaviour;
    }

    internal static class ParserDiagnostics
    {
        public static void ThrowParserException(string message)
        {
            throw new PdfReaderException(message);
        }

        public static void ThrowParserException(string message, Exception innerException)
        {
            throw new PdfReaderException(message, innerException);
        }

        public static void HandleUnexpectedCharacter(char ch)
        {
            // Hex formatting does not work with type char. It must be casted to integer.
            string message = string.Format(CultureInfo.InvariantCulture,
                "Unexpected character '0x{0:x4}' in PDF stream. The file may be corrupted. " +
                "If you think this is a bug in PDFsharp, please send us your PDF file.", (int)ch);
            ThrowParserException(message);
        }
        public static void HandleUnexpectedToken(string token)
        {
            string message = string.Format(CultureInfo.InvariantCulture,
                "Unexpected token '{0}' in PDF stream. The file may be corrupted. " +
                "If you think this is a bug in PDFsharp, please send us your PDF file.", token);
            ThrowParserException(message);
        }
    }

    internal static class ContentReaderDiagnostics
    {
        public static void ThrowContentReaderException(string message)
        {
            throw new ContentReaderException(message);
        }

        public static void ThrowContentReaderException(string message, Exception innerException)
        {
            throw new ContentReaderException(message, innerException);
        }

        public static void ThrowNumberOutOfIntegerRange(long value)
        {
            string message = string.Format(CultureInfo.InvariantCulture, "Number '{0}' out of integer range.", value);
            ThrowContentReaderException(message);
        }

        public static void HandleUnexpectedCharacter(char ch)
        {
            string message = string.Format(CultureInfo.InvariantCulture,
                "Unexpected character '0x{0:x4}' in content stream. The stream may be corrupted or the feature is not implemented. " +
                "If you think this is a bug in PDFsharp, please send us your PDF file.", (int)ch);
            ThrowContentReaderException(message);
        }
    }
}
