using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchantService.Applications.MerchantMediator.Request;
using MerchantService.Model;
using Microsoft.AspNetCore.Mvc;

namespace MerchantService.Applications.MerchantMediator.Commands
{
    public class DeleteMerchantCommandHandler : IRequestHandler<DeleteMerchantCommand, MerchantDTO>
    {
        private readonly MerchantContext _context;

        public DeleteMerchantCommandHandler(MerchantContext context)
        {
            _context = context;
        }

        public async Task<MerchantDTO> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Merchants.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.Merchants.Remove(data);
            await _context.SaveChangesAsync();

            return new MerchantDTO { Message = "Successfull", Success = true };
        }
    }
}
