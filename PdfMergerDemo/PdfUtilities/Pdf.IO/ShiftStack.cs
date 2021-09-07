#define GDI


using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PdfSharp.Pdf.IO
{
    /// <summary>
    /// Represents the stack for the shift-reduce parser. It seems that it is only needed for
    /// reduction of indirect references.
    /// </summary>
    internal class ShiftStack
    {
        // TODO: make Lexer.PeekChars(20) and scan for 'R' to detect indirect references

        public ShiftStack()
        {
            _items = new List<PdfItem>();
        }

        public PdfItem[] ToArray(int start, int length)
        {
            PdfItem[] items = new PdfItem[length];
            for (int i = 0, j = start; i < length; i++, j++)
                items[i] = _items[j];
            return items;
        }

        /// <summary>
        /// Gets the stack pointer index.
        /// </summary>
        // ReSharper disable InconsistentNaming
        public int SP
        // ReSharper restore InconsistentNaming
        {
            get { return _sp; }
        }

        /// <summary>
        /// Gets the value at the specified index. Valid index is in range 0 up to sp-1.
        /// </summary>
        public PdfItem this[int index]
        {
            get
            {
                if (index >= _sp)
                    throw new ArgumentOutOfRangeException("index", index, "Value greater than stack index.");
                return _items[index];
            }
        }

        /// <summary>
        /// Gets an item relative to the current stack pointer. The index must be a negative value (-1, -2, etc.).
        /// </summary>
        public PdfItem GetItem(int relativeIndex)
        {
            if (relativeIndex >= 0 || -relativeIndex > _sp)
                throw new ArgumentOutOfRangeException("relativeIndex", relativeIndex, "Value out of stack range.");
            return _items[_sp + relativeIndex];
        }

        /// <summary>
        /// Gets an item relative to the current stack pointer. The index must be a negative value (-1, -2, etc.).
        /// </summary>
        public int GetInteger(int relativeIndex)
        {
            if (relativeIndex >= 0 || -relativeIndex > _sp)
                throw new ArgumentOutOfRangeException("relativeIndex", relativeIndex, "Value out of stack range.");
            return ((PdfInteger)_items[_sp + relativeIndex]).Value;
        }

        /// <summary>
        /// Pushes the specified item onto the stack.
        /// </summary>
        public void Shift(PdfItem item)
        {
            Debug.Assert(item != null);
            _items.Add(item);
            _sp++;
        }

        /// <summary>
        /// Replaces the last 'count' items with the specified item.
        /// </summary>
        public void Reduce(int count)
        {
            if (count > _sp)
                throw new ArgumentException("count causes stack underflow.");
            _items.RemoveRange(_sp - count, count);
            _sp -= count;
        }

        /// <summary>
        /// Replaces the last 'count' items with the specified item.
        /// </summary>
        public void Reduce(PdfItem item, int count)
        {
            Debug.Assert(item != null);
            Reduce(count);
            _items.Add(item);
            _sp++;
        }

        /// <summary>
        /// The stack pointer index. Points to the next free item.
        /// </summary>
        int _sp;

        /// <summary>
        /// An array representing the stack.
        /// </summary>
        readonly List<PdfItem> _items;
    }
}
