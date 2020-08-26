using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Impl;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Data;
using PetShop.UI.OwnerMenu;
using PetShop.UI.PetExchangeMenu;
using PetShop.UI.PetMenu;

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
            serviceCollection.AddScoped<IPetExchangeService, PetExchangeService>();

            serviceCollection.AddScoped<MainMenu>();
            serviceCollection.AddScoped<PetMainMenu>();
            serviceCollection.AddScoped<PetShowcaseMenu>();
            serviceCollection.AddScoped<PetSearchMenu>();
            serviceCollection.AddScoped<PetDeleteMenu>();
            serviceCollection.AddScoped<OwnerMainMenu>();
            serviceCollection.AddScoped<OwnerDeleteMenu>();
            serviceCollection.AddScoped<PetExchangeMainMenu>();
            serviceCollection.AddScoped<PetExchangeRegisterMenu>();
            serviceCollection.AddScoped<PetExchangeUnregisterMenu>();
            serviceCollection.AddScoped<PetExchangeShowcaseMenu>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var petRepository = serviceProvider.GetRequiredService<IPetRepository>(); 
            var ownerRepository = serviceProvider.GetRequiredService<IOwnerRepository>(); 
            var mainMenu = serviceProvider.GetRequiredService<MainMenu>();

            petRepository.CreateInitialData();
            ownerRepository.CreateInitialData();
            mainMenu.Run();
        }
    }
}
