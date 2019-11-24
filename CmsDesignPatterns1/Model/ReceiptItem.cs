using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDesignPatterns1.Model
{
    class ReceiptItem
    {
        public ReceiptItem()
        {
            Quantity = 0;
        }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
