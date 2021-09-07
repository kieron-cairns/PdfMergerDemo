#define GDI


using System;
#if GDI
using System.Drawing;
#endif
#if WPF
using System.Windows;
#endif
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Fonts;

namespace PdfSharp.Internal
{
    /// <summary>
    /// A bunch of internal helper functions.
    /// </summary>
    internal static class DiagnosticsHelper
    {
        public static void HandleNotImplemented(string message)
        {
            string text = "Not implemented: " + message;
            switch (Diagnostics.NotImplementedBehaviour)
            {
                case NotImplementedBehaviour.DoNothing:
                    break;

                case NotImplementedBehaviour.Log:
                    Logger.Log(text);
                    break;

                case NotImplementedBehaviour.Throw:
                    ThrowNotImplementedException(text);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Indirectly throws NotImplementedException.
        /// Required because PDFsharp Release builds tread warnings as errors and
        /// throwing NotImplementedException may lead to unreachable code which
        /// crashes the build.
        /// </summary>
        public static void ThrowNotImplementedException(string message)
        {
            throw new NotImplementedException(message);
        }
    }

    internal static class Logger
    {
        public static void Log(string format, params object[] args)
        {
            Debug.WriteLine("Log...");
        }
    }

    class Logging
    {

    }

    class Tracing
    {
        [Conditional("DEBUG")]
        public void Foo()
        { }
    }

    /// <summary>
    /// Helper class around the Debugger class.
    /// </summary>
    public static class DebugBreak
    {
        /// <summary>
        /// Call Debugger.Break() if a debugger is attached.
        /// </summary>
        public static void Break()
        {
            Break(false);
        }

        /// <summary>
        /// Call Debugger.Break() if a debugger is attached or when always is set to true.
        /// </summary>
        public static void Break(bool always)
        {
#if DEBUG
            if (always || Debugger.IsAttached)
                Debugger.Break();
#endif
        }
    }

    /// <summary>
    /// Internal stuff for development of PDFsharp.
    /// </summary>
    public static class FontsDevHelper
    {
        /// <summary>
        /// Creates font and enforces bold/italic simulation.
        /// </summary>
        public static XFont CreateSpecialFont(string familyName, double emSize, XFontStyle style,
            XPdfFontOptions pdfOptions, XStyleSimulations styleSimulations)
        {
            return new XFont(familyName, emSize, style, pdfOptions, styleSimulations);
        }

        /// <summary>
        /// Dumps the font caches to a string.
        /// </summary>
        public static string GetFontCachesState()
        {
            return FontFactory.GetFontCachesState();
        }
    }
}
