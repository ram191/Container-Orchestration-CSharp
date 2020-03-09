using System;
using MediatR;

namespace CustomerService.Application.Queries.CustomerPaymentCardMediator.GetCPC
{
    public class GetCustomerPaymentCardQuery : IRequest<GetCustomerPaymentCardDTO>
    {
        public int Id { get; set; }

        public GetCustomerPaymentCardQuery(int _id)
        {
            Id = _id;
        }
    }
}
