using System;
using MediatR;

namespace CustomerService.Application.Queries.CustomerMediator.GetCustomer
{
    public class GetCustomerQuery : IRequest<GetCustomerDTO>
    {
        public int Id { get; set; }

        public GetCustomerQuery(int _id)
        {
            Id = _id;
        }
    }
}
