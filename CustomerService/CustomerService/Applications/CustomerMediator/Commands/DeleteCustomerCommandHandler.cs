using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerService.Application.CustomerMediator.Request;
using CustomerService.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Application.CustomerMediator.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, CustomerDTO>
    {
        private readonly CustomerContext _context;

        public DeleteCustomerCommandHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<CustomerDTO> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Customers.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.Customers.Remove(data);
            await _context.SaveChangesAsync();

            return new CustomerDTO { Message = "Successfull", Success = true };
        }
    }
}
