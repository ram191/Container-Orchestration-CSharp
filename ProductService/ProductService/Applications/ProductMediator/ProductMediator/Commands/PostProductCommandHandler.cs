using System;
using System.Threading;
using System.Threading.Tasks;
using ProductService.Application.Queries.ProductMediator.GetProduct;
using ProductService.Model;
using MediatR;

namespace ProductService.Application.ProductMediator.Commands
{
    public class PostProductCommandHandler : IRequestHandler<ProductCommand, GetProductDTO>
    {
        private readonly ProductContext _context;

        public PostProductCommandHandler(ProductContext context)
        {
            _context = context;
        }

        public async Task<GetProductDTO> Handle(ProductCommand request, CancellationToken cancellationToken)
        {
            _context.Products.Add(request.Data.Attributes);
            await _context.SaveChangesAsync();

            return new GetProductDTO
            {
                Message = "Successfully Added",
                Success = true,
                Data = new ProductData
                {
                    Id = request.Data.Attributes.Id,
                    Merchant_id = request.Data.Attributes.Merchant_id,
                    Name = request.Data.Attributes.Name,
                    Price = request.Data.Attributes.Price,
                }
            };
        }
    }
}
