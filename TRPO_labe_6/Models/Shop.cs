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
        public List<Product> Products { get; set; }

        public override string ToString()
        {
            return $"Shop - {nameof(Name)} : {Name}";
        }

        public Shop(string name)
        {
            Name = name;
            Assistants = new List<ShopAssistant>();
            Products = new List<Product>();
        }

        public Shop()
        {
            Assistants = new List<ShopAssistant>();
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            var itemProduct = Products.SingleOrDefault(x => x.Equals(product));
            if (itemProduct == null)
                Products.Add(product);
            else
                itemProduct.Count++;
        }

        public bool SellProduct(ShopAssistant assistant, Product product)
        {
            var assist = Assistants.SingleOrDefault(x => x.Equals(assistant));
            var itemProduct = Products.SingleOrDefault(x => x.Equals(product));
            if (assist == null)
                return false;
            if (itemProduct == null)
                return false;
            if (itemProduct.Count == 0)
                return false;
            assistant.SellProduct(itemProduct);
            itemProduct.Count--;
            return true;
        }

        public int CalculateOverall() => Assistants.Sum(x => x.SelledProducts.Sum(y => y.Price * y.Count));
    }
}
