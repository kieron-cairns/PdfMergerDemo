#define GDI


namespace PdfSharp.Fonts
{
    /// <summary>
    /// Provides functionality that converts a requested typeface into a physical font.
    /// </summary>
    public interface IFontResolver
    {
        /// <summary>
        /// Converts specified information about a required typeface into a specific font.
        /// </summary>
        /// <param name="familyName">Name of the font family.</param>
        /// <param name="isBold">Set to <c>true</c> when a bold fontface is required.</param>
        /// <param name="isItalic">Set to <c>true</c> when an italic fontface is required.</param>
        /// <returns>Information about the physical font, or null if the request cannot be satisfied.</returns>
        FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic);

        //FontResolverInfo ResolveTypeface(Typeface); TODO in PDFsharp 2.0

        /// <summary>
        /// Gets the bytes of a physical font with specified face name.
        /// </summary>
        /// <param name="faceName">A face name previously retrieved by ResolveTypeface.</param>
        byte[] GetFont(string faceName);
    }
}