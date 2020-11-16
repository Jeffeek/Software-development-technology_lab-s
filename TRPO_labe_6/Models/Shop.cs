using System;
using System.Collections.Generic;
using System.Linq;

namespace TRPO_labe_6.Models
{
    [Serializable]
    public class Shop
    {
        public string Name { get; set; }
        public List<ShopAssistant> Assistants { get; }
        public Dictionary<Product, int> Products { get; }

        public Shop(string name)
        {
            Assistants = new List<ShopAssistant>();
            Products = new Dictionary<Product, int>();
        }

        public void AddProduct(Product product)
        {
            if (Products.Keys.SingleOrDefault(x => x.Equals(product)) == null)
                Products.Add(product, 1);
            else
                Products[product]++;
        }

        public bool SellProduct(ShopAssistant assistant, Product product)
        {
            if (Assistants.SingleOrDefault(x => x.Equals(assistant)) == null)
                return false;
            if (Products.Keys.SingleOrDefault(x => x.Equals(product)) == null)
                return false;
            if (Products[product] == 0)
                return false;
            assistant.SellProduct(product);
            Products[product]--;
            return true;
        }

        public int CalculateOverall() => Assistants.Sum(x => x.SelledProducts.Sum(y => y.Price));
    }
}
