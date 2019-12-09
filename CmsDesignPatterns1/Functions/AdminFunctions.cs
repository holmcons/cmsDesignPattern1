using CmsDesignPatterns1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDesignPatterns1.Functions
{
    class AdminFunctions
    {
        private readonly IProductRepository productRepository;

        public AdminFunctions(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Run()
        {
            while (true)
            {
                var menu = new UI.SelectionMenu("Admin", new[] {
                    "Ny product",
                    "Ändra product",
                    }, true);
                int sel = menu.RenderAndSelect(true);
                if (sel == 0) break;
                if (sel == 1)
                    NewProduct();
                if (sel == 2)
                    ChangeProduct();
            }

        }

        private void ChangeProduct()
        {
            
            var products = productRepository.GetAll();

            var menu = new UI.SelectionMenu("Select which product to change", products.Select(r=>r.Name).ToArray()  , true);
            int sel = menu.RenderAndSelect(true);
            if (sel == 0) return;
            var p = products[sel - 1];
            EditProduct(p);
        }

        private void EditProduct(Product p)
        {
            Console.WriteLine("*** bla bla -- fake edit --- lets say we wanna add 100 kr to price");
            Console.WriteLine("press a key");
            Console.ReadKey();
            p.Price = p.Price + 100;
            productRepository.SaveProduct(p);
        }

        private void NewProduct()
        {
            throw new NotImplementedException();
        }

    }
}
