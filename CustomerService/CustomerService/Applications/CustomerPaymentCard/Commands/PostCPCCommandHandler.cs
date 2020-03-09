using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerService.Application.Queries.CustomerPaymentCardMediator.GetCPC;
using CustomerService.Model;
using MediatR;

namespace CustomerService.Application.CustomerPaymentCardMediator.Commands
{
    public class PostCustomerCommandHandler : IRequestHandler<CustomerPaymentCardCommand, GetCustomerPaymentCardDTO>
    {
        private readonly CustomerContext _context;

        public PostCustomerCommandHandler(CustomerContext context)
        {
            _context = context;
        }

        async Task<GetCustomerPaymentCardDTO> IRequestHandler<CustomerPaymentCardCommand, GetCustomerPaymentCardDTO>.Handle(CustomerPaymentCardCommand request, CancellationToken cancellationToken)
        {
            _context.CustomerPaymentCards.Add(request.Data.Attributes);
            await _context.SaveChangesAsync();
            return new GetCustomerPaymentCardDTO
            {
                Message = "Success retreiving data",
                Success = true,
                Data = new CustomerPaymentCardData
                {
                    Id = request.Data.Attributes.Id,
                    Customer_id = request.Data.Attributes.Customer_id,
                    Name_on_card = request.Data.Attributes.Name_on_card,
                    Exp_month = request.Data.Attributes.Exp_month,
                    Exp_year = request.Data.Attributes.Exp_year,
                    Postal_code = request.Data.Attributes.Postal_code,
                    Credit_card_number = request.Data.Attributes.Credit_card_number
                }
            };
        }
    }
}
