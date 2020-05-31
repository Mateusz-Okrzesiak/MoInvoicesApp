using AutoMapper;
using MoInvoices.Pages;

namespace MoInvoices.Core.Customer
{

    public interface ICustomerService
    {
        public Customer GetCustomer(int id);
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

        public Customer GetCustomer(int id)
        {

        }
    }
}
