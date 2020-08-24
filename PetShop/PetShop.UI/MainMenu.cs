using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.Entities;
using PetShop.UI.PetMenu;
using System;

namespace PetShop.UI
{
    public class MainMenu: Menu
    {
        private IServiceProvider serviceProvider;

        public MainMenu(IServiceProvider serviceProvider) : base("Main Menu", "Pet Menu", "Owner Menu")
        {
            this.serviceProvider = serviceProvider;
        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    serviceProvider.GetRequiredService<PetMainMenu>().Run();
                    break;
                case 2:
                    serviceProvider.GetRequiredService<OwnerMenu>().Run();
                    break;
                default:
                    break;
            }
        }
    }
}
