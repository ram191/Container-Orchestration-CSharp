using System;
using System.Collections.Generic;
using CustomerService.Application.Queries.CustomerPaymentCardMediator.GetCPC;
using CustomerService.Model;
using MediatR;

namespace CustomerService.Application.Queries.CustomerPaymentCardMediator.GetCPCs
{
    public class GetCustomerPaymentCardsDTO : BaseDTO
    {
        public List<CustomerPaymentCardData> Data { get; set; }
    }
}
