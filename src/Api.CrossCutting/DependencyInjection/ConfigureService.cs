using Api.Service.Services;
using Api.Domain.Interfaces.Client;
using Api.Domain.Interfaces.Product;
using Api.Domain.Interfaces.Provider;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService    
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IClientService, ClientService>();
            serviceCollection.AddTransient<IProviderService, ProviderService>();
            serviceCollection.AddTransient<IProductService, ProductService>();
        }
    }
}