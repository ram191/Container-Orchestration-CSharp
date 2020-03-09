using System;
using System.Threading;
using System.Threading.Tasks;
using ProductService.Application.ProductMediator.Request;
using ProductService.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Application.ProductMediator.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductDTO>
    {
        private readonly ProductContext _context;

        public DeleteProductCommandHandler(ProductContext context)
        {
            _context = context;
        }

        public async Task<ProductDTO> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Products.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.Products.Remove(data);
            await _context.SaveChangesAsync();

            return new ProductDTO { Message = "Successfull", Success = true };
        }
    }
}
