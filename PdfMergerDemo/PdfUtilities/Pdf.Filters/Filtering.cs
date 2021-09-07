#define GDI


using System;
using System.Diagnostics;

namespace PdfSharp.Pdf.Filters
{
    /// <summary>
    /// Applies standard filters to streams.
    /// </summary>
    public static class Filtering
    {
        /// <summary>
        /// Gets the filter specified by the case sensitive name.
        /// </summary>
        public static Filter GetFilter(string filterName)
        {
            if (filterName.StartsWith("/"))
                filterName = filterName.Substring(1);

            // Some tools use abbreviations
            switch (filterName)
            {
                case "ASCIIHexDecode":
                case "AHx":
                    return _asciiHexDecode ?? (_asciiHexDecode = new AsciiHexDecode());

                case "ASCII85Decode":
                case "A85":
                    return _ascii85Decode ?? (_ascii85Decode = new Ascii85Decode());

                case "LZWDecode":
                case "LZW":
                    return _lzwDecode ?? (_lzwDecode = new LzwDecode());

                case "FlateDecode":
                case "Fl":
                    return _flateDecode ?? (_flateDecode = new FlateDecode());

                //case "RunLengthDecode":
                //  if (RunLengthDecode == null)
                //    RunLengthDecode = new RunLengthDecode();
                //  return RunLengthDecode;
                //
                //case "CCITTFaxDecode":
                //  if (CCITTFaxDecode == null)
                //    CCITTFaxDecode = new CCITTFaxDecode();
                //  return CCITTFaxDecode;
                //
                //case "JBIG2Decode":
                //  if (JBIG2Decode == null)
                //    JBIG2Decode = new JBIG2Decode();
                //  return JBIG2Decode;
                //
                //case "DCTDecode":
                //  if (DCTDecode == null)
                //    DCTDecode = new DCTDecode();
                //  return DCTDecode;
                //
                //case "JPXDecode":
                //  if (JPXDecode == null)
                //    JPXDecode = new JPXDecode();
                //  return JPXDecode;
                //
                //case "Crypt":
                //  if (Crypt == null)
                //    Crypt = new Crypt();
                //  return Crypt;

                case "RunLengthDecode":
                case "CCITTFaxDecode":
                case "JBIG2Decode":
                case "DCTDecode":
                case "JPXDecode":
                case "Crypt":
                    Debug.WriteLine("Filter not implemented: " + filterName);
                    return null;
            }
            throw new NotImplementedException("Unknown filter: " + filterName);
        }

        /// <summary>
        /// Gets the filter singleton.
        /// </summary>
        // ReSharper disable InconsistentNaming
        public static AsciiHexDecode ASCIIHexDecode
        // ReSharper restore InconsistentNaming
        {
            get { return _asciiHexDecode ?? (_asciiHexDecode = new AsciiHexDecode()); }
        }
        static AsciiHexDecode _asciiHexDecode;

        /// <summary>
        /// Gets the filter singleton.
        /// </summary>
        public static Ascii85Decode ASCII85Decode
        {
            get { return _ascii85Decode ?? (_ascii85Decode = new Ascii85Decode()); }
        }
        static Ascii85Decode _ascii85Decode;

        /// <summary>
        /// Gets the filter singleton.
        /// </summary>
        public static LzwDecode LzwDecode
        {
            get { return _lzwDecode ?? (_lzwDecode = new LzwDecode()); }
        }
        static LzwDecode _lzwDecode;

        /// <summary>
        /// Gets the filter singleton.
        /// </summary>
        public static FlateDecode FlateDecode
        {
            get { return _flateDecode ?? (_flateDecode = new FlateDecode()); }
        }
        static FlateDecode _flateDecode;

        //runLengthDecode
        //ccittFaxDecode
        //jbig2Decode
        //dctDecode
        //jpxDecode
        //crypt

        /// <summary>
        /// Encodes the data with the specified filter.
        /// </summary>
        public static byte[] Encode(byte[] data, string filterName)
        {
            Filter filter = GetFilter(filterName);
            if (filter != null)
                return filter.Encode(data);
            return null;
        }

        /// <summary>
        /// Encodes a raw string with the specified filter.
        /// </summary>
        public static byte[] Encode(string rawString, string filterName)
        {
            Filter filter = GetFilter(filterName);
            if (filter != null)
                return filter.Encode(rawString);
            return null;
        }

        /// <summary>
        /// Decodes the data with the specified filter.
        /// </summary>
        public static byte[] Decode(byte[] data, string filterName, FilterParms parms)
        {
            Filter filter = GetFilter(filterName);
            if (filter != null)
                return filter.Decode(data, parms);
            return null;
        }

        /// <summary>
        /// Decodes the data with the specified filter.
        /// </summary>
        public static byte[] Decode(byte[] data, string filterName)
        {
            Filter filter = GetFilter(filterName);
            if (filter != null)
                return filter.Decode(data, null);
            return null;
        }

        /// <summary>
        /// Decodes the data with the specified filter.
        /// </summary>
        public static byte[] Decode(byte[] data, PdfItem filterItem)
        {
            byte[] result = null;
            if (filterItem is PdfName)
            {
                Filter filter = GetFilter(filterItem.ToString());
                if (filter != null)
                    result = filter.Decode(data);
            }
            else if (filterItem is PdfArray)
            {
                PdfArray array = (PdfArray)filterItem;
                foreach (PdfItem item in array)
                    data = Decode(data, item);
                result = data;
            }
            return result;
        }

        /// <summary>
        /// Decodes to a raw string with the specified filter.
        /// </summary>
        public static string DecodeToString(byte[] data, string filterName, FilterParms parms)
        {
            Filter filter = GetFilter(filterName);
            if (filter != null)
                return filter.DecodeToString(data, parms);
            return null;
        }

        /// <summary>
        /// Decodes to a raw string with the specified filter.
        /// </summary>
        public static string DecodeToString(byte[] data, string filterName)
        {
            Filter filter = GetFilter(filterName);
            if (filter != null)
                return filter.DecodeToString(data, null);
            return null;
        }
    }
}