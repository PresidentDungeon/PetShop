using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Impl;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Data;
using System;

namespace PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();

            serviceCollection.AddScoped<MainMenu>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var mainMenu = serviceProvider.GetRequiredService<MainMenu>();
            mainMenu.Run();
        }
    }
}
