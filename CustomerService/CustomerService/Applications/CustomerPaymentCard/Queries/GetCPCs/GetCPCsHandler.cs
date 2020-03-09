using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CustomerService.Model;
using CustomerService.Application.Queries.CustomerPaymentCardMediator.GetCPC;

namespace CustomerService.Application.Queries.CustomerPaymentCardMediator.GetCPCs
{
    public class GetCustomerPaymentCardsQueryHandler : IRequestHandler<GetCustomerPaymentCardsQuery, GetCustomerPaymentCardsDTO>
    {
        private readonly CustomerContext _context;

        public GetCustomerPaymentCardsQueryHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<GetCustomerPaymentCardsDTO> Handle(GetCustomerPaymentCardsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.CustomerPaymentCards.ToListAsync();
            var result = new List<CustomerPaymentCardData>();

            foreach (var x in data)
            {
                result.Add(new CustomerPaymentCardData
                {
                    Id = x.Id,
                    Customer_id = x.Customer_id,
                    Name_on_card = x.Name_on_card,
                    Exp_month = x.Exp_month,
                    Exp_year = x.Exp_year,
                    Postal_code = x.Postal_code,
                    Credit_card_number = x.Credit_card_number
                });
            }

            return new GetCustomerPaymentCardsDTO
            {
                Message = "Success retrieving data",
                Success = true,
                Data = result
            };
        }
    }
}
