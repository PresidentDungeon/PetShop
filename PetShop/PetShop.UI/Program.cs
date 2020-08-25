using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Impl;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Data;
using PetShop.UI.OwnerMenu;
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
            serviceCollection.AddScoped<IOwnerRepository, OwnerRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IOwnerService, OwnerService>();

            serviceCollection.AddScoped<MainMenu>();
            serviceCollection.AddScoped<PetMainMenu>();
            serviceCollection.AddScoped<PetShowcaseMenu>();
            serviceCollection.AddScoped<PetSearchMenu>();
            serviceCollection.AddScoped<PetDeleteMenu>();
            serviceCollection.AddScoped<OwnerMainMenu>();
            serviceCollection.AddScoped<OwnerDeleteMenu>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var PetRepository = serviceProvider.GetRequiredService<IPetRepository>(); 
            var OwnerRepository = serviceProvider.GetRequiredService<IOwnerRepository>(); 
            var MainMenu = serviceProvider.GetRequiredService<MainMenu>();

            PetRepository.CreateInitialData();
            OwnerRepository.CreateInitialData();
            MainMenu.Run();
        }
    }
}
