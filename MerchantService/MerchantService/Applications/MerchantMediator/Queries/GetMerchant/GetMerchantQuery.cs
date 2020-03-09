using System;
using MediatR;

namespace MerchantService.Applications.MerchantMediator.Queries.GetMerchant
{
    public class GetMerchantQuery : IRequest<GetMerchantDTO>
    {
        public int Id { get; set; }

        public GetMerchantQuery(int _id)
        {
            Id = _id;
        }
    }
}
