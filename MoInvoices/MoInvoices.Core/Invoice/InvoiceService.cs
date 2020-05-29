using AutoMapper;
using MoInvoices.Models;
using MoInvoices.Pages;
using MoInvoices.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoInvoices.Core
{
    public interface IInvoiceService
    {
         bool AddNewInvoice(InvoiceDTO invoice);
        InvoiceDTO GetInvoice(int invoiceID);
         IEnumerable<InvoiceListDTO> GetAllUserInvoices(int userID);
    }

    public class InvoiceService : IInvoiceService
    {
        private readonly MoInvoiceContext _context;
        private readonly IMapper _mapper;
        public InvoiceService(IMapper mapper, MoInvoiceContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool AddNewInvoice(InvoiceDTO invoice)
        {
            try
            {
                var newInvoice = _mapper.Map<Invoice>(invoice);

                _context.Invoice.Add(newInvoice);
                _context.SaveChanges();

                foreach (var row in invoice.Service)
                {
                    var invoiceRowService = _mapper.Map<InvoiceRowService>(row);
                    invoiceRowService.InvoiceID = newInvoice.InvoiceID;
                    _context.InvoiceRowService.Add(invoiceRowService);
                }

                Contractor purchaser = _mapper.Map<Contractor>(invoice.Purchaser);
                Contractor vendor = _mapper.Map<Contractor>(invoice.Vendor);

                _context.Contractor.Add(purchaser);
                _context.Contractor.Add(vendor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            return true;
        }

        public InvoiceDTO GetInvoice(int invoiceID)
        {
            var invoice = _context.Invoice.Where(u => u.InvoiceID == invoiceID).SingleOrDefault();
            return _mapper.Map<InvoiceDTO>(invoice);
        }
        public IEnumerable<InvoiceListDTO> GetAllUserInvoices(int userID)
        {
            IEnumerable<InvoiceListDTO> invoiceList = (IEnumerable<InvoiceListDTO>)_context.Invoice.Where(u => u.UserId == userID)
                                                      .Select(x => _mapper.Map<Invoice, InvoiceDTO>(x));

            return invoiceList;
        }
    }
}
