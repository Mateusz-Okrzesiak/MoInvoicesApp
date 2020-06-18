using DinkToPdf;
using DinkToPdf.Contracts;
using MoInvoices.DTO;
using MoInvoices.PDF.Template;
using RazorLight;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace MoInvoices.Web.Utility
{
    public interface IPDFService
    {
        Task<byte[]> Create(InvoiceDTO invoice);
    }
    public class PDFService : IPDFService
    {
        private readonly IConverter _pdfConverter;

        public PDFService(IConverter pdfConverter)
        {
            _pdfConverter = pdfConverter;
        }

        public async Task<byte[]> Create(InvoiceDTO invoice)
        {
            // var templatePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), $"Pages/test.cshtml");
            string template = await InvoiceVAT.GetInvoiceVAT(invoice);
            var globalSettings = SetGlobalSettings(invoice.InvoiceNumber + "_" + DateTime.Now.ToString());
            var objectSettings = SetObjectSettings(template);

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            byte[] file = _pdfConverter.Convert(pdf);

            return file;
        }

        public GlobalSettings SetGlobalSettings(string documentTitle)
        {
            return new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings() { Top = 10, Bottom = 10, Left = 10, Right = 10 },
                DocumentTitle = documentTitle,
            };
        }

        public ObjectSettings SetObjectSettings(string template)
        {
            return new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = template,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial", FontSize = 12, Line = true, Center = "Fun pdf document" },
                FooterSettings = { FontName = "Arial", FontSize = 12, Line = true, Right = "Page [page] of [toPage]" }
            };
        }


    }
}
