using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDesignPatterns1
{
    class Program
    {
        static void Main(string[] args)
        {
            var productRepository = new Functions.ProductFileHandler();

            var adminFunctions = new Functions.AdminFunctions(productRepository);
            var cashRegisterFunctions = new Functions.CashRegisterFunctions(productRepository);

            while (true)
            {
                int sel = MainMenu();
                if (sel == 0) break;
                else if (sel == 1) { cashRegisterFunctions.Run(); }
                else if (sel == 2) { adminFunctions.Run(); }
            }
        }

        private static int MainMenu()
        {
            var menu = new UI.SelectionMenu("HUVUDMENY", new[] {
                "Registrera försäljning (kassa)",
                "Administration"
            }, true);
            return menu.RenderAndSelect(true);

        }
    }
}
