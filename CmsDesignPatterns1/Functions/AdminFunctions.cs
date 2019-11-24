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
            var products = new List<Product>();
            //Thank god filehandling and splitting is so EASY in C#
            foreach (var fileRow in System.IO.File.ReadAllLines("..\\..\\Products-Data.txt"))
            {
                var prodParts = fileRow.Split('|');
                if (prodParts.Length < 4) continue;
                var selectedProduct = new Product(prodParts[0]);
                selectedProduct.Name = prodParts[1];
                selectedProduct.Price = Convert.ToDecimal(prodParts[2]);
                products.Add(selectedProduct);
            }


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

            //Save to file
            var allLines = System.IO.File.ReadAllLines("..\\..\\Products-Data.txt");
            for(int i = 0; i < allLines.Length; i++)
            {
                var fileRow = allLines[i];
                var prodParts = fileRow.Split('|');
                if (prodParts.Length < 4) continue;
                if(prodParts[0] == p.Id)
                {
                    var newRow = p.Id + "|" + p.Name + "|" + p.Price.ToString();
                    allLines[i] = newRow;
                }
            }
            System.IO.File.WriteAllLines("..\\..\\Products-Data.txt",allLines);

        }

        private void NewProduct()
        {
            throw new NotImplementedException();
        }

    }
}
