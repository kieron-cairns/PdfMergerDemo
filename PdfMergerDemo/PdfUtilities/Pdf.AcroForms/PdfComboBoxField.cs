#define GDI


using System;

namespace PdfSharp.Pdf.AcroForms
{
    /// <summary>
    /// Represents the combo box field.
    /// </summary>
    public sealed class PdfComboBoxField : PdfChoiceField
    {
        /// <summary>
        /// Initializes a new instance of PdfComboBoxField.
        /// </summary>
        internal PdfComboBoxField(PdfDocument document)
            : base(document)
        { }

        internal PdfComboBoxField(PdfDictionary dict)
            : base(dict)
        { }

        /// <summary>
        /// Gets or sets the index of the selected item.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                string value = Elements.GetString(Keys.V);
                return IndexInOptArray(value);
            }
            set
            {
                // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx		  
                if (value != -1) //R080325
                {
                    string key = ValueInOptArray(value);
                    Elements.SetString(Keys.V, key);
                    Elements.SetInteger("/I", value); //R080304 !!!!!!! sonst reagiert die Combobox überhaupt nicht !!!!!
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of the field.
        /// </summary>
        // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx		  
        public override PdfItem Value //R080304
        {
            get { return Elements[Keys.V]; }
            set
            {
                if (ReadOnly)
                    throw new InvalidOperationException("The field is read only.");
                if (value is PdfString || value is PdfName)
                {
                    Elements[Keys.V] = value;
                    SelectedIndex = SelectedIndex; //R080304 !!!
                    if (SelectedIndex == -1)
                    {
                        //R080317 noch nicht rund
                        try
                        {
                            //anhängen
                            ((PdfArray)(((PdfItem[])(Elements.Values))[2])).Elements.Add(Value);
                            SelectedIndex = SelectedIndex;
                        }
                        catch { }
                    }
                }
                else
                    throw new NotImplementedException("Values other than string cannot be set.");
            }
        }

        /// <summary>
        /// Predefined keys of this dictionary. 
        /// The description comes from PDF 1.4 Reference.
        /// </summary>
        public new class Keys : PdfAcroField.Keys
        {
            // Combo boxes have no additional entries.

            internal static DictionaryMeta Meta
            {
                get
                {
                    if (Keys._meta == null)
                        Keys._meta = CreateMeta(typeof(Keys));
                    return Keys._meta;
                }
            }
            static DictionaryMeta _meta;
        }

        /// <summary>
        /// Gets the KeysMeta of this dictionary type.
        /// </summary>
        internal override DictionaryMeta Meta
        {
            get { return Keys.Meta; }
        }
    }
}
