﻿using AutoMapper;
using MoInvoices.Models;
using MoInvoices.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using MoInvoices.DTO;
using Microsoft.EntityFrameworkCore;
using MoInvoices.Data.Models;

namespace MoInvoices.Core
{
    public interface IInvoiceService
    {
        void AddNewInvoice(InvoiceDTO invoice);
        void UpdateInvoice(InvoiceDTO invoice);
        void DeleteInvoice(int id);
        InvoiceDTO GetInvoice(int invoiceID);
        IEnumerable<InvoiceListDTO> GetAllUserInvoices(int userID);


        IEnumerable<DocumentType> GetDocumentTypes();
        IEnumerable<PaymentType> GetPaymentTypes();
        IEnumerable<PaymentStatus> GetPaymentStatuses();
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

        public void AddNewInvoice(InvoiceDTO invoice)
        {
            try
            {
                var newInvoice = _mapper.Map<Invoice>(invoice);

                _context.Invoice.Add(newInvoice);
                _context.SaveChanges();

                foreach (var row in invoice.Services)
                {
                    var invoiceRowService = _mapper.Map<InvoiceRowService>(row);
                    invoiceRowService.InvoiceID = newInvoice.InvoiceID;
                    _context.InvoiceRowService.Add(invoiceRowService);
                }

                Contractor purchaser = _mapper.Map<Contractor>(invoice.Purchaser);
                Contractor vendor = _mapper.Map<Contractor>(invoice.Vendor);

                purchaser.ContractorTypeID = (int)Enum.ContractorType.Purchaser;
                vendor.ContractorTypeID = (int)Enum.ContractorType.Vendor;

                _context.Contractor.Add(purchaser);
                _context.Contractor.Add(vendor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public void UpdateInvoice(InvoiceDTO editInvoice)
        {
            var invoice = _context.Invoice.SingleOrDefault(i => i.InvoiceID.Equals(editInvoice.InvoiceID));
            invoice = _mapper.Map<Invoice>(editInvoice);
         //   invoice.Contractors = editInvoice.Purchaser;

            _context.Update(invoice);
            _context.SaveChanges();
        }

        public void DeleteInvoice(int id)
        {
            var invoice = _context.Invoice.Find(id);
            _context.Remove(invoice);

            _context.SaveChanges();
        }

        public InvoiceDTO GetInvoice(int invoiceID)
        {
            var invoice = _context.Invoice.Find(invoiceID);
            return _mapper.Map<InvoiceDTO>(invoice);
        }

        public IEnumerable<InvoiceListDTO> GetAllUserInvoices(int userID)
        {
            var invoiceList = _context.Invoice.Where(u => u.UserId.Equals(userID))
                                          .Select(x => _mapper.Map<InvoiceListDTO>(x));
       
            return invoiceList;
        }


        #region metody pobierające typy
        public IEnumerable<DocumentType> GetDocumentTypes()
        {
            return _context.DocumentType.ToList();
        }

        public IEnumerable<PaymentType> GetPaymentTypes()
        {
            return _context.PaymentType.ToList();
        }

        public IEnumerable<PaymentStatus> GetPaymentStatuses()
        {
            return _context.PaymentStatus.ToList();
        }
        #endregion

    }
}
