using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDesignPatterns1.Model
{
    class Receipt
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public decimal ItemsTotal
        {
            get
            {
                return Rows.Sum(r => r.ProductPrice * r.Quantity);
            }
        }

        public decimal ReceiptRabatt
        {
            get
            {
                if (ItemsTotal >= 2000) return -0.03m * ItemsTotal;
                if (ItemsTotal >= 1000) return -0.02m * ItemsTotal;
                return 0;
            }
        }


        public decimal ReceiptTotal
        {
            get
            {
                return ItemsTotal + ReceiptRabatt;
            }
        }


        public List<ReceiptItem> Rows { get; set; }
        public Receipt()
        {
            DateTime = DateTime.Now;
            Rows = new List<ReceiptItem>();
        }

        internal void AddToReceipt(Product prod, int quantity)
        {
            var item = Rows.FirstOrDefault(r => r.ProductId == prod.Id);
            if (item == null)
            {
                item = new ReceiptItem();
                item.ProductId = prod.Id;
                item.ProductName = prod.Name;
                item.ProductPrice = prod.Price;
                Rows.Add(item);
            }
            item.Quantity += quantity;
        }
    }
}
