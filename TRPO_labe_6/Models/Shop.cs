using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TRPO_labe_6.Models
{
    [DataContract]
    public class Shop
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<ShopAssistant> Assistants { get; set; }
        [DataMember]
        public List<ValueTuple<Product, int>> Products { get; set; }

        public override string ToString()
        {
            return $"Shop - {nameof(Name)} : {Name}";
        }

        public Shop(string name)
        {
            Name = name;
            Assistants = new List<ShopAssistant>();
            Products = new List<(Product, int)>();
        }

        public Shop()
        {
            
        }

        public void AddProduct(Product product)
        {
            var itemProduct = Products.SingleOrDefault(x => x.Item1.Equals(product));
            if (itemProduct.Item1 == null)
                Products.Add((product, 1));
            else
                itemProduct.Item2++;
        }

        public bool SellProduct(ShopAssistant assistant, Product product)
        {
            var assist = Assistants.SingleOrDefault(x => x.Equals(assistant));
            var itemProduct = Products.SingleOrDefault(x => x.Item1.Equals(product));
            if (assist == null)
                return false;
            if (itemProduct.Item1 == null)
                return false;
            if (itemProduct.Item2 == 0)
                return false;
            assistant.SellProduct(itemProduct.Item1);
            itemProduct.Item2--;
            return true;
        }

        public int CalculateOverall() => Assistants.Sum(x => x.SelledProducts.Sum(y => y.Price));
    }
}
