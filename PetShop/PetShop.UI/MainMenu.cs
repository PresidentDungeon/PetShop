using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.Entities;
using PetShop.UI.PetMenu;
using System;

namespace PetShop.UI
{
    public class MainMenu: Menu
    {
        private IServiceProvider ServiceProvider;

        public MainMenu(IServiceProvider serviceProvider) : base("Main Menu", "Pet Menu", "Owner Menu")
        {
            this.ServiceProvider = serviceProvider;
        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    ServiceProvider.GetRequiredService<PetMainMenu>().Run();
                    break;
                case 2:
                    ServiceProvider.GetRequiredService<OwnerMainMenu>().Run();
                    break;
                default:
                    break;
            }
        }
    }
}
