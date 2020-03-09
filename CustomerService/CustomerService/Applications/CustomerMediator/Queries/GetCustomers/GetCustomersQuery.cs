using System;
using MediatR;

namespace CustomerService.Application.Queries.CustomerMediator.GetCustomers
{
    public class GetCustomersQuery : IRequest<GetCustomersDTO>
    {
    }
}
