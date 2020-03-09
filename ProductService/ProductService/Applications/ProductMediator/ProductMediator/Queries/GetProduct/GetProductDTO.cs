using System;
using System.Collections.Generic;
using ProductService.Model;
using MediatR;

namespace ProductService.Application.Queries.ProductMediator.GetProduct
{
    public class GetProductDTO : BaseDTO
    {
        public ProductData Data { get; set; }
    }

    public class ProductData
    {
        public int Id { get; set; }
        public int Merchant_id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
