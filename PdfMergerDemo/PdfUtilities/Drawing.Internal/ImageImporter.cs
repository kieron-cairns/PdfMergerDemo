#define GDI


using System.Collections.Generic;
using System.IO;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing.Internal
{
    /// <summary>
    /// The class that imports images of various formats.
    /// </summary>
    internal class ImageImporter
    {
        // TODO Make a singleton!
        /// <summary>
        /// Gets the image importer.
        /// </summary>
        public static ImageImporter GetImageImporter()
        {
            return new ImageImporter();
        }

        private ImageImporter()
        {
            _importers.Add(new ImageImporterJpeg());
            _importers.Add(new ImageImporterBmp());
            // TODO: Special importer for PDF? Or dealt with at a higher level?
        }

        /// <summary>
        /// Imports the image.
        /// </summary>
        public ImportedImage ImportImage(Stream stream, PdfDocument document)
        {
            StreamReaderHelper helper = new StreamReaderHelper(stream);

            // Try all registered importers to see if any of them can handle the image.
            foreach (IImageImporter importer in _importers)
            {
                helper.Reset();
                ImportedImage image = importer.ImportImage(helper, document);
                if (image != null)
                    return image;
            }
            return null;
        }

#if GDI || WPF || CORE
        /// <summary>
        /// Imports the image.
        /// </summary>
        public ImportedImage ImportImage(string filename, PdfDocument document)
        {
            ImportedImage ii;
            using (Stream fs = File.OpenRead(filename))
            {
                ii = ImportImage(fs, document);
            }
            return ii;
        }
#endif

        private readonly List<IImageImporter> _importers = new List<IImageImporter>();
    }
}
