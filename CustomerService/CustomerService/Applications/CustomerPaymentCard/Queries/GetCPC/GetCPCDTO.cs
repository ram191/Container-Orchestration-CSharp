﻿using System;
using System.Collections.Generic;
using CustomerService.Model;
using MediatR;

namespace CustomerService.Application.Queries.CustomerPaymentCardMediator.GetCPC

{
    public class GetCustomerPaymentCardDTO : BaseDTO
    {
        public CustomerPaymentCardData Data { get; set; }
    }

    public class CustomerPaymentCardData
    {
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public string Name_on_card { get; set; }
        public string Exp_month { get; set; }
        public string Exp_year { get; set; }
        public int Postal_code { get; set; }
        public string Credit_card_number { get; set; }

    }
}
