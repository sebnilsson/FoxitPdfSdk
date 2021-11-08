using System;
using System.IO;
using foxit.common;
using foxit.common.fxcrt;
using foxit.pdf;
using foxit.pdf.interform;
using FoxitPdfSdk.Products;
using Microsoft.Extensions.Options;
using Path = System.IO.Path;

namespace FoxitPdfSdk.Pdfs
{
    internal class PdfGenerator : IPdfGenerator, IDisposable
    {
        private readonly FoxitPdfOptions _foxitPdf;

        public PdfGenerator(IOptionsMonitor<FoxitPdfOptions> options)
        {
            _foxitPdf = options.CurrentValue;

            InitFoxitPdf();
        }

        public Stream GenerateForProduct(Product product)
        {
            using var doc = new PDFDoc();
            using var form = new Form(doc);
            using var page = doc.InsertPage(0, PDFPage.Size.e_SizeLetter);

            AddProductFields(product, form, page);

            page.Flatten(true, (int)PDFPage.FlattenOptions.e_FlattenAll);

            return GetPdfStream(doc);
        }

        private static void AddProductFields(Product product, Form form, PDFPage page)
        {
            const int offset = 60;

            AddField("ID", $"ID: {product.Id}", 0 * offset, form, page);
            AddField("Product", product.Name, 1 * offset, form, page);
            AddField("Price", $"Price: {product.Price}", 2 * offset, form, page);
        }

        private static void AddField(string title, string text, int offset, Form form, PDFPage page)
        {
            var rect = new RectF(50f, 600f - offset, 500f, 640f - offset);

            using var control =
                form.AddControl(page, title, Field.Type.e_TypeTextField, rect);

            using var field = control.GetField();

            field.SetValue(text);
        }

        private static string GetPdfFilePath()
        {
            var tempPath = Path.GetTempPath();
            var tempName = Path.ChangeExtension(Path.GetTempFileName(), "pdf");
            return Path.Combine(tempPath, tempName);
        }

        private static Stream GetPdfStream(PDFDoc doc)
        {
            var filePath = GetPdfFilePath();

            doc.SaveAs(filePath, (int)PDFDoc.SaveFlags.e_SaveFlagNoOriginal);

            doc.ClearRenderCache();

            var memoryStream = new MemoryStream();

            using var fileStream = File.OpenRead(filePath);
            fileStream.Position = 0;
            fileStream.CopyTo(memoryStream);
            fileStream.Close();

            memoryStream.Position = 0;

            File.Delete(filePath);

            return memoryStream;
        }

        private void InitFoxitPdf()
        {
            var result = Library.Initialize(_foxitPdf.SerialNo, _foxitPdf.Key);
            if (result != ErrorCode.e_ErrSuccess)
            {
                throw new ApplicationException($"Failed to initialize Foxit PDF SDK: {result}");
            }
        }

        public void Dispose()
        {
            Library.Release();
        }
    }
}
