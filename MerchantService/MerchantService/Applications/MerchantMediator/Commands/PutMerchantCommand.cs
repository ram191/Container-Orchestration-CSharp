using System;
using MediatR;
using MerchantService.Applications.MerchantMediator.Queries.GetMerchant;
using MerchantService.Model;

namespace MerchantService.Applications.MerchantMediator.Commands
{
    public class PutMerchantCommand : CommandDTO<Merchant>, IRequest<GetMerchantDTO>
    {
    }
}
