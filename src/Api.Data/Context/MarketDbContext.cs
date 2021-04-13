using System;
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MarketDbContext : DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<ProviderEntity> Providers { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClientEntity>(new ClientMap().Configure);
            modelBuilder.Entity<ProviderEntity>(new ProviderMap().Configure);
            modelBuilder.Entity<ProductEntity>(new ProductMap().Configure);

            modelBuilder.Entity<ClientEntity>().HasData(
                new ClientEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrator",
                    Email = "rodriguesalves.roberta@gmail.com",
                    Password = "mudar@123",
                    Document = "567.789.345-87",
                    CreatAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                });
        }
    }
}