using CmsDesignPatterns1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDesignPatterns1.Functions
{
    interface IProductRepository
    {
        List<Product> GetAll();
        void SaveProduct(Product p);
    }

    class ProductDatabaseHandler : IProductRepository
    {
        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveProduct(Product p)
        {
            throw new NotImplementedException();
        }
    }

    class ProductFileHandler : IProductRepository
    {
        public List<Product> GetAll()
        {
            var products = new List<Product>();
            foreach (var fileRow in System.IO.File.ReadAllLines("..\\..\\Products-Data.txt"))
            {
                var prodParts = fileRow.Split('|');
                if (prodParts.Length < 4) continue;
                var selectedProduct = new Product(prodParts[0]);
                selectedProduct.Name = prodParts[1];
                selectedProduct.Price = Convert.ToDecimal(prodParts[2]);
                products.Add(selectedProduct);
            }
            return products;
        }

        public void SaveProduct(Product p)
        {
            //Save to file
            var allLines = System.IO.File.ReadAllLines("..\\..\\Products-Data.txt");
            for (int i = 0; i < allLines.Length; i++)
            {
                var fileRow = allLines[i];
                var prodParts = fileRow.Split('|');
                if (prodParts.Length < 4) continue;
                if (prodParts[0] == p.Id)
                {
                    var newRow = p.Id + "|" + p.Name + "|" + p.Price.ToString();
                    allLines[i] = newRow;
                }
            }
            System.IO.File.WriteAllLines("..\\..\\Products-Data.txt", allLines);

        }

    }
}
