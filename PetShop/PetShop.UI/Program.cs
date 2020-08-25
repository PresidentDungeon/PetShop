using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Impl;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Data;
using PetShop.UI.PetMenu;
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
            serviceCollection.AddScoped<PetMainMenu>();
            serviceCollection.AddScoped<PetShowcaseMenu>();
            serviceCollection.AddScoped<PetSearchMenu>();
            serviceCollection.AddScoped<PetDeleteMenu>();
            serviceCollection.AddScoped<OwnerMenu>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var PetRepository = serviceProvider.GetRequiredService<IPetRepository>(); 
            var MainMenu = serviceProvider.GetRequiredService<MainMenu>();

            PetRepository.CreateInitialData();
            MainMenu.Run();
        }
    }
}
