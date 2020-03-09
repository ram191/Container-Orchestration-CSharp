﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Application.Commands;
using CustomerService.Application.CustomerMediator.Commands;
using CustomerService.Application.Queries.CustomerMediator.GetCustomer;
using CustomerService.Application.Queries.CustomerMediator.GetCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediatr;

        public CustomerController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = new GetCustomersQuery();
            return Ok(await _mediatr.Send(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var command = new GetCustomerQuery(id);
            var result = await _mediatr.Send(command);
            return result != null ? (IActionResult)Ok(result) : NotFound(new { Message = "Customer not found" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand(id);
            var result = await _mediatr.Send(command);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "Customer not found" });
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CustomerCommand data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PutCustomerCommand data)
        {
            data.Data.Attributes.Id = id;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }
    }
}
