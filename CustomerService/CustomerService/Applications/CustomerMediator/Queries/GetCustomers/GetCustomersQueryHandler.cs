using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CustomerService.Model;
using CustomerService.Application.Queries.CustomerMediator.GetCustomer;

namespace CustomerService.Application.Queries.CustomerMediator.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersDTO>
    {
        private readonly CustomerContext _context;

        public GetCustomersQueryHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<GetCustomersDTO> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Customers.ToListAsync();
            var result = new List<CustomerData>();

            foreach(var x in data)
            {
                result.Add(new CustomerData
                {
                    Id = x.Id,
                    Full_name = x.Full_name,
                    Username = x.Username,
                    Birthdate = x.Birthdate,
                    Password = x.Password,
                    Gender = Enum.GetName(typeof(Gender), x.Sex),
                    Email = x.Email,
                    Phone_number = x.Phone_number
                });
            }

            return new GetCustomersDTO
            {
                Message = "Success retrieving data",
                Success = true,
                Data = result
            };
        }
    }
}
