using System;
using System.Collections.Generic;
using CustomerService.Application.Queries.CustomerMediator.GetCustomer;
using CustomerService.Model;
using MediatR;

namespace CustomerService.Application.Queries.CustomerMediator.GetCustomers
{
    public class GetCustomersDTO : BaseDTO
    {
        public List<CustomerData> Data { get; set; }
    }
}
