using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerService.Application.CustomerPaymentCardMediator.Request;
using CustomerService.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Application.CustomerPaymentCardMediator.Commands
{
    public class DeleteCustomerPaymentCardCommandHandler : IRequestHandler<DeleteCustomerPaymentCardCommand, CustomerPaymentCardDTO>
    {
        private readonly CustomerContext _context;

        public DeleteCustomerPaymentCardCommandHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<CustomerPaymentCardDTO> Handle(DeleteCustomerPaymentCardCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.CustomerPaymentCards.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.CustomerPaymentCards.Remove(data);
            await _context.SaveChangesAsync();

            return new CustomerPaymentCardDTO { Message = "Successfull", Success = true };
        }
    }
}
