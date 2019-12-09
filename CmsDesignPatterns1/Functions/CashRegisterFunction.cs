using CmsDesignPatterns1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDesignPatterns1.Functions
{
    class CashRegisterFunctions
    {
        private readonly IProductRepository productRepository;

        public CashRegisterFunctions(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Run()
    {
        while (true)
        {
            var menu = new UI.SelectionMenu("KASSA", new[] {
                    "Ny kund",
                    }, true);
            int sel = menu.RenderAndSelect(true);
            if (sel == 0) break;
            if (sel == 1)
                CashRegisterDoCustomer();
        }

    }
    private void ShowReceipt(Receipt receipt)
    {
        Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("KVITTO   " + receipt.DateTime.ToString("yyyy-MM-dd hh:mm:ss"));
        foreach (var item in receipt.Rows)
        {
            Console.WriteLine($"{item.ProductName} {item.Quantity} * {item.ProductPrice} = {item.Quantity * item.ProductPrice}");
        }
        if (receipt.ReceiptRabatt != 0m)
        {
            Console.WriteLine($"Items total: {receipt.ItemsTotal:0.00}");
            Console.WriteLine($"Rabatt: {receipt.ReceiptRabatt:0.00}");
        }
        Console.WriteLine($"Total: {receipt.ReceiptTotal:0.00}");
    }

    private bool HandleProduct(string line, Receipt receipt)
    {
        string[] parts = line.Split(' ');
        if (parts.Length != 2) return false;
        var productId = parts[0];
        int quantity;
        if (!int.TryParse(parts[1], out quantity))
        {
            Console.WriteLine("Felaktigt antal"); return false;
        }

        var selectedProduct = productRepository.GetProduct(productId);
        if(selectedProduct == null)
        { 
            Console.WriteLine("Produkt saknas"); 
            return false; 
        }
        receipt.AddToReceipt(selectedProduct, quantity);
        return true;

    }
    private void CashRegisterDoCustomer()
    {
        var receipt = new Receipt();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("KASSA");

            ShowReceipt(receipt);

            Console.ResetColor();
            Console.WriteLine("kommandon:");
            Console.WriteLine("<productid> <antal>");
            Console.WriteLine("PAY");
            Console.Write("Kommando:");
            string input = Console.ReadLine();
            if (input == "PAY")
            {
                Console.WriteLine("Faking we get paid");
                Console.WriteLine("Saving to receiptfile for today...");
                System.Threading.Thread.Sleep(3000);
                break;
            }
            if (!HandleProduct(input, receipt))
                System.Threading.Thread.Sleep(3000);
        }
    }

}
}
