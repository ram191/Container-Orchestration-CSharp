using System;
using MediatR;
using MerchantService.Applications.MerchantMediator.Request;
using Microsoft.AspNetCore.Mvc;

namespace MerchantService.Applications.MerchantMediator.Commands
{
    public class DeleteMerchantCommand : IRequest<MerchantDTO>
    {
        public int Id { get; set; }

        public DeleteMerchantCommand(int id)
        {
            Id = id;
        }
    }
}
