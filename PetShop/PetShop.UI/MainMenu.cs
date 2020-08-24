using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

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
                    serviceProvider.GetRequiredService<PetMenu>().Run();
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
