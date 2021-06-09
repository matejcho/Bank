using Bank.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Data
{
    public class BankDbContext
    : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options)
        : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(account =>
            {
                account.Property(q => q.Id).IsRequired();
                account.HasKey(q => q.Id);
                account.Property(q => q.Name).HasMaxLength(20).IsRequired();
                account.Property(q => q.Balance).IsRequired();
                account.Property(q => q.IsActive).IsRequired();
                account.Property(q => q.AccountTypeId).IsRequired();
            });
            modelBuilder.Entity<Address>(address => {
                address.Property(a => a.Id).IsRequired();
                address.HasKey(a => a.Id);
                address.Property(a => a.City).IsRequired();
                address.Property(a => a.Country).IsRequired();
                address.Property(a => a.Street).IsRequired();
            });
            modelBuilder.Entity<Client>(client =>
            {
                client.Property(c => c.Id).IsRequired();
                client.HasKey(c => c.Id);
                client.Property(c => c.Name).HasMaxLength(20).IsRequired();
                client.Property(c => c.PhoneNumber).HasMaxLength(20).IsRequired();
                client.Property(c => c.Email).IsRequired();
                client.Property(c => c.ClientTypeId).IsRequired();
            });
        }

    }
}
