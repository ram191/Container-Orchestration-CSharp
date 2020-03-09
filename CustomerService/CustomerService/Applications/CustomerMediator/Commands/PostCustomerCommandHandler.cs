﻿using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerService.Application.Queries.CustomerMediator.GetCustomer;
using CustomerService.Model;
using MediatR;

namespace CustomerService.Application.CustomerMediator.Commands
{
    public class PostCustomerCommandHandler : IRequestHandler<CustomerCommand, GetCustomerDTO>
    {
        private readonly CustomerContext _context;

        public PostCustomerCommandHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<GetCustomerDTO> Handle(CustomerCommand request, CancellationToken cancellationToken)
        {
            if (request.Data.Attributes.Gender == "male")
            {
                request.Data.Attributes.Sex = Gender.male;
            }
            else if (request.Data.Attributes.Gender == "female")
            {
                request.Data.Attributes.Sex = Gender.female;
            }
            _context.Customers.Add(request.Data.Attributes);
            await _context.SaveChangesAsync();

            return new GetCustomerDTO
            {
                Message = "Successfully Added",
                Success = true,
                Data = new CustomerData
                {
                    Id = request.Data.Attributes.Id,
                    Full_name = request.Data.Attributes.Full_name,
                    Username = request.Data.Attributes.Username,
                    Birthdate = request.Data.Attributes.Birthdate,
                    Password = request.Data.Attributes.Password,
                    Gender = Enum.GetName(typeof(Gender), request.Data.Attributes.Sex),
                    Email = request.Data.Attributes.Email,
                    Phone_number = request.Data.Attributes.Phone_number
                }
            };
        }
    }
}
