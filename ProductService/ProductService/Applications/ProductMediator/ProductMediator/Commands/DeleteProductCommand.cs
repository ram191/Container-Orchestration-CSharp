using System;
using ProductService.Application.ProductMediator.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Application.ProductMediator.Commands
{
    public class DeleteProductCommand : IRequest<ProductDTO>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
