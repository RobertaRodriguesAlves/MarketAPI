using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MarketDbContext>
    {
        public MarketDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Persist Security Info=True;Server=localhost;Port=3306;Database=dbMarketApi;Uid=root;Pwd=985206";
            var optionsBuilder = new DbContextOptionsBuilder<MarketDbContext>();
            optionsBuilder.UseMySql(connectionString,
                    new MySqlServerVersion(new Version(8, 0, 21)),
                        mySqlOptions => mySqlOptions
                        .CharSetBehavior(CharSetBehavior.NeverAppend));
            return new MarketDbContext(optionsBuilder.Options);
        }
    }
}