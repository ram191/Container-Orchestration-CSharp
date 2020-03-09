using System;
using MediatR;

namespace ProductService.Application.Queries.ProductMediator.GetProducts
{
    public class GetProductsQuery : IRequest<GetProductsDTO>
    {
    }
}
