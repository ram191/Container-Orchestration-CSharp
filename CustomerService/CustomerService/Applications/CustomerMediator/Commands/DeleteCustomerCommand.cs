using System;
using CustomerService.Application.CustomerMediator.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Application.CustomerMediator.Commands
{
    public class DeleteCustomerCommand : IRequest<CustomerDTO>
    {
        public int Id { get; set; }

        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
