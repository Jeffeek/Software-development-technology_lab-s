using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TRPO_labe_6.Models
{
    [DataContract]
    public class ShopAssistant : IEquatable<ShopAssistant>
    {
        public override string ToString()
        {
            return $"ShopAssistant - {nameof(Name)}: {Name}, {nameof(Age)}: {Age}, {nameof(HiringDate)}: {HiringDate}";
        }

        public ShopAssistant(string name, int age, DateTime hiringDate)
        {
            Name = name;
            Age = age;
            HiringDate = hiringDate;
            SelledProducts = new List<Product>();
        }

        public ShopAssistant()
        {
            SelledProducts = new List<Product>();
        }

        private const int DefaultSalary = 10000;
        [DataMember]
        public List<Product> SelledProducts { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public DateTime HiringDate { get; set; }


        public void SellProduct(Product product)
        {
            SelledProducts.Add(product);
        }

        public double CalculateSalary()
        {
            if (SelledProducts.Count == 0)
                return DefaultSalary;
            return DefaultSalary + (SelledProducts.Count / 0.1);
        }

        public bool Equals(ShopAssistant other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && Age == other.Age && HiringDate.Equals(other.HiringDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShopAssistant) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Age;
                hashCode = (hashCode * 397) ^ HiringDate.GetHashCode();
                return hashCode;
            }
        }
    }
}
