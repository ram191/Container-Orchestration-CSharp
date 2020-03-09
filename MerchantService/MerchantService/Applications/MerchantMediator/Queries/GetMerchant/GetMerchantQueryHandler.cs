using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MerchantService.Model;

namespace MerchantService.Applications.MerchantMediator.Queries.GetMerchant
{
    public class GetMerchantQueryHandler : IRequestHandler<GetMerchantQuery, GetMerchantDTO>
    {
        private readonly MerchantContext _context;

        public GetMerchantQueryHandler(MerchantContext context)
        {
            _context = context;
        }

        async Task<GetMerchantDTO> IRequestHandler<GetMerchantQuery, GetMerchantDTO>.Handle(GetMerchantQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Merchants.FindAsync(request.Id);

            if (data == null)
            {
                data = null;
            }

            return new GetMerchantDTO
            {
                Message = "Success retreiving data",
                Success = true,
                Data = new MerchantData {
                    Id = data.Id,
                    Name = data.Name,
                    Image = data.Image,
                    Address = data.Address,
                    Rating = data.Rating,
                }
            };

        }
    }
}
