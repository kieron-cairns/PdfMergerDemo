#define GDI


namespace PdfSharp.Pdf.Advanced
{
    /// <summary>
    /// Provides access to the internal PDF object data structures. This class prevents the public
    /// interfaces from pollution with to much internal functions.
    /// </summary>
    public class PdfObjectInternals
    {
        internal PdfObjectInternals(PdfObject obj)
        {
            _obj = obj;
        }
        readonly PdfObject _obj;

        /// <summary>
        /// Gets the object identifier. Returns PdfObjectID.Empty for direct objects.
        /// </summary>
        public PdfObjectID ObjectID
        {
            get { return _obj.ObjectID; }
        }

        /// <summary>
        /// Gets the object number.
        /// </summary>
        public int ObjectNumber
        {
            get { return _obj.ObjectID.ObjectNumber; }
        }

        /// <summary>
        /// Gets the generation number.
        /// </summary>
        public int GenerationNumber
        {
            get { return _obj.ObjectID.GenerationNumber; }
        }

        /// <summary>
        /// Gets the name of the current type.
        /// Not a very useful property, but can be used for data binding.
        /// </summary>
        public string TypeID
        {
            get
            {
                if (_obj is PdfArray)
                    return "array";
                if (_obj is PdfDictionary)
                    return "dictionary";
                return _obj.GetType().Name;
            }
        }
    }
}
