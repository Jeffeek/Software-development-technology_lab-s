using System;
using System.Collections.Generic;

namespace TRPO_labe_6.Models
{
    [Serializable]
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
        }

        public ShopAssistant()
        {
            
        }

        private const int DefaultSalary = 10000;
        public List<Product> SelledProducts { get; }
        public string Name { get; }
        public int Age { get; }
        public DateTime HiringDate { get; }


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
