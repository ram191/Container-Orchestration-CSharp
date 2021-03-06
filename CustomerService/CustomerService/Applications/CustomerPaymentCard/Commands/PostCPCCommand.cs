﻿using System;
using CustomerService.Application.Queries.CustomerPaymentCardMediator.GetCPC;
using CustomerService.Model;
using MediatR;

namespace CustomerService.Application.CustomerPaymentCardMediator.Commands
{
    public class CustomerPaymentCardCommand : CommandDTO<CustomerPaymentCard>, IRequest<GetCustomerPaymentCardDTO>
    {
    }
}
