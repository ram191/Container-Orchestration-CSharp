﻿using System;
using System.Collections.Generic;
using MediatR;
using MerchantService.Model;

namespace MerchantService.Applications.MerchantMediator.Queries.GetMerchant
{
    public class GetMerchantDTO : BaseDTO
    {
        public MerchantData Data { get; set; }
    }

    public class MerchantData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
    }
}
