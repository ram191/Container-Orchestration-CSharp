using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MerchantService.Applications.MerchantMediator.Commands;
using MerchantService.Applications.MerchantMediator.Queries.GetMerchant;
using MerchantService.Applications.MerchantMediator.Queries.GetMerchants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MerchantService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MerchantController : ControllerBase
    {
        private IMediator _mediatr;

        public MerchantController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<GetMerchantsDTO>> Get()
        {
            var result = new GetMerchantsQuery();
            return Ok(await _mediatr.Send(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = new GetMerchantQuery(id);
            return result != null ? (IActionResult)Ok(await _mediatr.Send(result)) : NotFound(new { Message = "Merchant not found" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMerchantCommand(id);
            var result = await _mediatr.Send(command);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "Merchant not found" });
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(MerchantCommand data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PutMerchantCommand data)
        {
            data.Data.Attributes.Id = id;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }
    }

}
