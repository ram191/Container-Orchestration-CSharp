using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchantService.Applications.MerchantMediator.Queries.GetMerchant;
using MerchantService.Model;

namespace MerchantService.Applications.MerchantMediator.Commands
{
    public class PutMerchantCommandHandler : IRequestHandler<PutMerchantCommand, GetMerchantDTO>
    {
        private readonly MerchantContext _context;

        public PutMerchantCommandHandler(MerchantContext context)
        {
            _context = context;
        }

        public async Task<GetMerchantDTO> Handle(PutMerchantCommand request, CancellationToken cancellationToken)
        {
            var query = await _context.Merchants.FindAsync(request.Data.Attributes.Id);
            query.Address = request.Data.Attributes.Address;
            query.Image = request.Data.Attributes.Image;
            query.Name = request.Data.Attributes.Name;
            query.Rating = request.Data.Attributes.Rating;
            query.Updated_at = DateTime.Now;
            _context.SaveChanges();
            return new GetMerchantDTO
            {
                Message = "Success retreiving data",
                Success = true,
                Data = new MerchantData
                {
                    Id = query.Id,
                    Address = query.Address,
                    Image = query.Image,
                    Name = query.Name,
                    Rating = query.Rating,
                }
            };
        }
    }
}
