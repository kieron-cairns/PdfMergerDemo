using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfMergerDemo
{
    public partial class Form1 : Form
    {
        string[] files;
        string outputFile = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCombine_Click(object sender, EventArgs e)
        {
            if (files == null || files.Length == 0 || outputFile is "")
            {
                MessageBox.Show("Select pdf files to merge and an output file name");
                return;
            }

            PdfDocument output = new PdfDocument();
            foreach (string file in files)
            {
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    PdfPage page = inputDocument.Pages[idx];
                    output.AddPage(page);
                }
            }

            output.Save(outputFile);
            MessageBox.Show("PDF files merged succesfully");
        }

        private void btnFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PDF files *.pdf | *.pdf";
            open.Multiselect = true;
            open.Title = "Select PDF Files";

            if (open.ShowDialog() == DialogResult.OK)
            {
                label1.Text = $"{open.FileNames.Length} files selected";
                files = open.FileNames;
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "output.pdf";
            savefile.Filter = "PDF files (*.pdf)|*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                outputFile = savefile.FileName;
                label2.Text = savefile.FileName;
            }
        }
    }
}
