using System;
using System.Threading;
using System.Threading.Tasks;
using ProductService.Application.Queries.ProductMediator.GetProduct;
using ProductService.Model;
using MediatR;

namespace ProductService.Application.ProductMediator.Commands
{
    public class PutProductCommandHandler : IRequestHandler<PutProductCommand, GetProductDTO>
    {
        private readonly ProductContext _context;

        public PutProductCommandHandler(ProductContext context)
        {
            _context = context;
        }

        public async Task<GetProductDTO> Handle(PutProductCommand request, CancellationToken cancellationToken)
        {
            var query = await _context.Products.FindAsync(request.Data.Attributes.Id);
            query.Merchant_id = request.Data.Attributes.Merchant_id;
            query.Name = request.Data.Attributes.Name;
            query.Price = request.Data.Attributes.Price;
            query.Updated_at = DateTime.Now;
            _context.SaveChanges();
            return new GetProductDTO
            {
                Message = "Success retreiving data",
                Success = true,
                Data = new ProductData
                {
                    Id = query.Id,
                    Merchant_id = query.Merchant_id,
                    Name = query.Name,
                    Price = query.Price,
                }
            };
        }
    }
}
