#define GDI


using System;
using System.ComponentModel;
using System.Threading;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Internal
{
    /// <summary>
    /// Static locking functions to make PDFsharp thread save.
    /// </summary>
    internal static class Lock
    {
        public static void EnterGdiPlus()
        {
            //if (_fontFactoryLockCount > 0)
            //    throw new InvalidOperationException("");

            Monitor.Enter(GdiPlus);
            _gdiPlusLockCount++;
        }

        public static void ExitGdiPlus()
        {
            _gdiPlusLockCount--;
            Monitor.Exit(GdiPlus);
        }

        static readonly object GdiPlus = new object();
        static int _gdiPlusLockCount;

        public static void EnterFontFactory()
        {
            Monitor.Enter(FontFactory);
            _fontFactoryLockCount++;
        }

        public static void ExitFontFactory()
        {
            _fontFactoryLockCount--;
            Monitor.Exit(FontFactory);
        }
        static readonly object FontFactory = new object();
        [ThreadStatic]
        static int _fontFactoryLockCount;
    }
}
