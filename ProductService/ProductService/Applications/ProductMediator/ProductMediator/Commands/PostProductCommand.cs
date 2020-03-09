using System;
using ProductService.Application.Queries.ProductMediator.GetProduct;
using ProductService.Model;
using MediatR;

namespace ProductService.Application.ProductMediator.Commands
{
    public class ProductCommand : CommandDTO<Product>, IRequest<GetProductDTO>
    {
    }
}
