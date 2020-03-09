using System;
using CustomerService.Application.Queries.CustomerMediator.GetCustomer;
using CustomerService.Model;
using MediatR;

namespace CustomerService.Application.CustomerMediator.Commands
{
    public class CustomerCommand : CommandDTO<Customer>, IRequest<GetCustomerDTO>
    {
    }
}
