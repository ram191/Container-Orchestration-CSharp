using System;
using MediatR;
using MerchantService.Applications.MerchantMediator.Queries.GetMerchant;
using MerchantService.Model;

namespace MerchantService.Applications.MerchantMediator.Commands
{
    public class MerchantCommand : CommandDTO<Merchant>, IRequest<GetMerchantDTO>
    {
    }
}
