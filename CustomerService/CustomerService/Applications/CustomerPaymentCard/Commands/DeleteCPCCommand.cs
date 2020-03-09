using System;
using CustomerService.Application.CustomerPaymentCardMediator.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Application.CustomerPaymentCardMediator.Commands
{
    public class DeleteCustomerPaymentCardCommand : IRequest<CustomerPaymentCardDTO>
    {
        public int Id { get; set; }

        public DeleteCustomerPaymentCardCommand(int id)
        {
            Id = id;
        }
    }
}
