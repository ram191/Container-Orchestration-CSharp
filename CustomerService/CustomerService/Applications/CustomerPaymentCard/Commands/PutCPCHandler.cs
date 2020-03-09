﻿using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerService.Application.CustomerPaymentCardMediator.Commands;
using CustomerService.Application.Queries.CustomerPaymentCardMediator.GetCPC;
using CustomerService.Model;
using MediatR;

namespace CustomerService.Application.Commands
{
    public class PutCustomerPaymentCardCommandHandler : IRequestHandler<PutCustomerPaymentCardCommand, GetCustomerPaymentCardDTO>
    {
        private readonly CustomerContext _context;

        public PutCustomerPaymentCardCommandHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<GetCustomerPaymentCardDTO> Handle(PutCustomerPaymentCardCommand request, CancellationToken cancellationToken)
        {
            var query = await _context.CustomerPaymentCards.FindAsync(request.Data.Attributes.Id);
            query.Id = query.Id;
            query.Customer_id = request.Data.Attributes.Customer_id;
            query.Name_on_card = request.Data.Attributes.Name_on_card;
            query.Exp_month = request.Data.Attributes.Exp_month;
            query.Exp_year = request.Data.Attributes.Exp_year;
            query.Postal_code = request.Data.Attributes.Postal_code;
            query.Credit_card_number = request.Data.Attributes.Credit_card_number;
            query.Updated_at = DateTime.Now;
            _context.SaveChanges();
            return new GetCustomerPaymentCardDTO
            {
                Message = "Success retreiving data",
                Success = true,
                Data = new CustomerPaymentCardData
                {
                    Id = query.Id,
                    Customer_id = query.Customer_id,
                    Name_on_card = query.Name_on_card,
                    Exp_month = query.Exp_month,
                    Exp_year = query.Exp_year,
                    Postal_code = query.Postal_code,
                    Credit_card_number = query.Credit_card_number
                }
            };
        }
    }
}
