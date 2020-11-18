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
        public XmlSerializableDictionary<Product, int> Products { get; }

        public override string ToString()
        {
            return $"Shop - {nameof(Name)} : {Name}";
        }

        public Shop(string name)
        {
            Name = name;
            Assistants = new List<ShopAssistant>();
            Products = new XmlSerializableDictionary<Product, int>();
        }

        public Shop()
        {
            
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
