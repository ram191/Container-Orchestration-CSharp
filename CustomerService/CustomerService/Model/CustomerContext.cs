using System;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Model
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPaymentCard> CustomerPaymentCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CustomerPaymentCard>()
                .HasOne(k => k.Customer)
                .WithMany()
                .HasForeignKey(k => k.Customer_id);
        }
    }
}
