using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MerchantService.Model;
using MerchantService.Applications.MerchantMediator.Queries.GetMerchant;

namespace MerchantService.Applications.MerchantMediator.Queries.GetMerchants
{
    public class GetMerchantsQueryHandler : IRequestHandler<GetMerchantsQuery, GetMerchantsDTO>
    {
        private readonly MerchantContext _context;

        public GetMerchantsQueryHandler(MerchantContext context)
        {
            _context = context;
        }

        public async Task<GetMerchantsDTO> Handle(GetMerchantsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Merchants.ToListAsync();
            var result = new List<MerchantData>();

            foreach(var x in data)
            {
                result.Add(new MerchantData
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    Address = x.Address,
                    Rating = x.Rating,
                });
            }

            return new GetMerchantsDTO
            {
                Message = "Success retrieving data",
                Success = true,
                Data = result
            };
        }
    }
}
