
using Microsoft.AspNetCore.Hosting;
using MoInvoices.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MoInvoices.Web
{
    public class InvoiceReport
    {

        //    private readonly IWebHostEnvironment _oHostingEnvironment;

        //    public InvoiceReport(IWebHostEnvironment oHostingEnvironment)
        //    {
        //        this._oHostingEnvironment = oHostingEnvironment;
        //    }

        //    int _maxColumn = 6;
        //    Document _document;
        //    Font _fontStyle;
        //    PdfPTable _pdfTable = new PdfPTable(3);
        //    MemoryStream _memoryStream = new MemoryStream();
        //    InvoiceDTO _invoiceDTO = new InvoiceDTO();

        //    public byte[] Report(InvoiceDTO invoice)
        //    {
        //        _invoiceDTO = invoice;
        //        _document.SetPageSize(PageSize.A4);
        //        _document.SetMargins(5f, 5f, 20f, 5f);
        //        _pdfTable.WidthPercentage = 100;

        //        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
        //        PdfWriter docWriter = PdfWriter.GetInstance(_document, _memoryStream);

        //        _document.Open();

        //        float[] sizes = new float[_maxColumn];
        //        for (int i = 0; i < _maxColumn; i++)
        //        {
        //            if (i == 0) sizes[i] = 20;
        //            else sizes[i] = 100;
        //        }
        //        _pdfTable.SetWidths(sizes);

        //        //this.ReportHeader
        //        //    this.Emptyr
        //            _pdfTable.HeaderRows = 6;
        //            _document.Add(_pdfTable);

        //            _document.Close();

        //            return _memoryStream.ToArray();



        //    }
        //}
    }
}
