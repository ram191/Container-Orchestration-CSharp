using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using CustomerService.Model;

namespace CustomerService.Application.Queries.CustomerPaymentCardMediator.GetCPC
{
    public class GetCustomerPaymentCardQueryHandler : IRequestHandler<GetCustomerPaymentCardQuery, GetCustomerPaymentCardDTO>
    {
        private readonly CustomerContext _context;

        public GetCustomerPaymentCardQueryHandler(CustomerContext context)
        {
            _context = context;
        }

        async Task<GetCustomerPaymentCardDTO> IRequestHandler<GetCustomerPaymentCardQuery, GetCustomerPaymentCardDTO>.Handle(GetCustomerPaymentCardQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.CustomerPaymentCards.FindAsync(request.Id);

            if (data == null)
            {
                data = null;
            }

            return new GetCustomerPaymentCardDTO
            {
                Message = "Success retreiving data",
                Success = true,
                Data = new CustomerPaymentCardData
                {
                    Id = data.Id,
                    Customer_id = data.Customer_id,
                    Name_on_card = data.Name_on_card,
                    Exp_month = data.Exp_month,
                    Exp_year = data.Exp_year,
                    Postal_code = data.Postal_code,
                    Credit_card_number = data.Credit_card_number
                }
            };

        }
    }
}
