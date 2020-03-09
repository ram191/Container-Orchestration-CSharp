using System;
using System.Collections.Generic;
using MediatR;
using MerchantService.Applications.MerchantMediator.Queries.GetMerchant;
using MerchantService.Model;

namespace MerchantService.Applications.MerchantMediator.Queries.GetMerchants
{
    public class GetMerchantsDTO : BaseDTO
    {
        public List<MerchantData> Data { get; set; }
    }
}
