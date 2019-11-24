using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDesignPatterns1.Model
{
    class Product
    {
        public string Id { get; protected set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public PriceType PriceType { get; set; }

        public Product()
        {

        }
        public Product(string id)
        {
            Id = id;
        }
        static public Product Deserialize(string line)
        {
            string[] parts = line.Split('|');
            if (parts.Length < 4) return null;
            var product = new Product
            {
                Id = parts[0],
                Name = parts[1],
                Price = decimal.Parse(parts[2]),
                PriceType = (PriceType)Enum.Parse(typeof(PriceType), parts[3])
            };
            return product;
        }
        public string Serialize()
        {
            return Id + "|" + Name + "|" + Price.ToString() + "|" + this.PriceType.ToString();
        }
    }
}
