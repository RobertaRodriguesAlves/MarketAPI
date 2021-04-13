using System;
using Api.Data.Context;
using Api.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IClientRepository, ClientRepository>();
            serviceCollection.AddScoped<IProviderRepository, ProviderRepository>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();

            serviceCollection.AddDbContext<MarketDbContext>(
                options => 
                options.UseMySql("Persist Security Info=True;Server=localhost;Port=3306;Database=dbMarketApi;Uid=root;Pwd=985206",
                        new MySqlServerVersion(new Version(8, 0, 21)),
                        mySqlOptions => mySqlOptions
                        .CharSetBehavior(CharSetBehavior.NeverAppend))
            );
        }
    }
}