using System;
using Microsoft.EntityFrameworkCore;

namespace MerchantService.Model
{
    public class MerchantContext : DbContext
    {
        public MerchantContext(DbContextOptions<MerchantContext> options) : base(options)
        {
        }

        public DbSet<Merchant> Merchants { get; set; }
    }
}
