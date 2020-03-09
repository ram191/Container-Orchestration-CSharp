using System;
using System.Collections.Generic;
using ProductService.Application.Queries.ProductMediator.GetProduct;
using ProductService.Model;
using MediatR;

namespace ProductService.Application.Queries.ProductMediator.GetProducts
{
    public class GetProductsDTO : BaseDTO
    {
        public List<ProductData> Data { get; set; }
    }
}
