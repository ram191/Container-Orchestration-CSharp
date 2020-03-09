using System;
using MediatR;

namespace MerchantService.Applications.MerchantMediator.Queries.GetMerchants
{
    public class GetMerchantsQuery : IRequest<GetMerchantsDTO>
    {
    }
}
