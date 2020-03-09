using System;
using MediatR;

namespace CustomerService.Application.Queries.CustomerPaymentCardMediator.GetCPCs
{
    public class GetCustomerPaymentCardsQuery : IRequest<GetCustomerPaymentCardsDTO>
    {
    }
}
