#define GDI


using System;

namespace PdfSharp.Pdf
{
    /// <summary>
    /// Base class for all dictionary Keys classes.
    /// </summary>
    public class KeysBase
    {
        internal static DictionaryMeta CreateMeta(Type type)
        {
            return new DictionaryMeta(type);
        }
    }
}
