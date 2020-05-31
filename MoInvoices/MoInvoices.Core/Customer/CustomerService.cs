using AutoMapper;
using MoInvoices.Pages;
using MoInvoices.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MoInvoices.Core.Customer
{

    public interface ICustomerService
    {
        public void AddCustomer(CustomerDTO customerDTO);
        public CustomerDTO GetCustomer(int id);
        public void UpdateCustomer(int id);
        public void DeleteCustomer(int id);
        public IEnumerable<CustomerListDTO> GetAllUserCustomers(int userID);

    }

    public class CustomerService : ICustomerService
    {
        private readonly MoInvoiceContext _context;
        private readonly IMapper _mapper;

        public CustomerService(IMapper mapper, MoInvoiceContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public CustomerDTO GetCustomer(int id)
        {
            var customer = _context.Customer.Find(id);

            return _mapper.Map<CustomerDTO>(customer);
        }

        public void AddCustomer(CustomerDTO customerDTO)
        {

        }

        public void UpdateCustomer(int id)
        {
            var customer = _context.Customer.Find(id);
            _context.Entry(customer);

            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customer.Find(id);
            _context.Remove(customer);
            
            _context.SaveChanges();
        }

        public IEnumerable<CustomerListDTO> GetAllUserCustomers(int userID)
        {
            var customerList = _context.Customer.Where(u => u.UserID.Equals(userID))
                                          .Select(x => _mapper.Map<CustomerListDTO>(x));

            return customerList;
        }
    }
}
