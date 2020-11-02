using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_labe_4.Real_Estate
{
    class Cottage : IRealEstate
    {
        private static double _housingRatio = 1.9;
        public double HousingRatio => _housingRatio;

        public int InsurancePeriod { get; }
        public double LivingSpace { get; }
        public int NumberOfResidents { get; }
        public int ConstructionYear { get; }
        public double Depreciation { get; }
        public double Price { get; }

        public Cottage(int insurancePeriod,
            double livingSpace,
            int numberOfResidents,
            int constructionYear,
            double depreciation,
            double price)
        {
            InsurancePeriod = insurancePeriod;
            LivingSpace = livingSpace;
            NumberOfResidents = numberOfResidents;
            ConstructionYear = constructionYear;
            Depreciation = depreciation;
            Price = price;
        }
    }
}
