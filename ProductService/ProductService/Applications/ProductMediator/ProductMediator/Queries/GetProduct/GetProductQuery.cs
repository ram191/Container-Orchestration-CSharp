using System;
using MediatR;

namespace ProductService.Application.Queries.ProductMediator.GetProduct
{
    public class GetProductQuery : IRequest<GetProductDTO>
    {
        public int Id { get; set; }

        public GetProductQuery(int _id)
        {
            Id = _id;
        }
    }
}
