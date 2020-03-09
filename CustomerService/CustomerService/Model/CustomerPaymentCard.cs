﻿using System;
namespace CustomerService.Model
{
    public class CustomerPaymentCard
    {
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public string Name_on_card { get; set; }
        public string Exp_month { get; set; }
        public string Exp_year { get; set; }
        public int Postal_code { get; set; }
        public string Credit_card_number { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; } = DateTime.Now;

        public Customer Customer { get; set; }
    }
}
