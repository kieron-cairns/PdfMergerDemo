﻿#define GDI


using System.Diagnostics;
using System.IO;

namespace PdfSharp.Fonts.OpenType
{
    /// <summary>
    /// Represents a writer for True Type font files. 
    /// </summary>
    internal class OpenTypeFontWriter : FontWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenTypeFontWriter"/> class.
        /// </summary>
        public OpenTypeFontWriter(Stream stream)
            : base(stream)
        { }

        /// <summary>
        /// Writes a table name.
        /// </summary>
        public void WriteTag(string tag)
        {
            Debug.Assert(tag.Length == 4);
            WriteByte((byte)(tag[0]));
            WriteByte((byte)(tag[1]));
            WriteByte((byte)(tag[2]));
            WriteByte((byte)(tag[3]));
        }
    }
}
