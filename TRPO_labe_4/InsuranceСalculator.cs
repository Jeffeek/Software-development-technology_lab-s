using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_4.Real_Estate;

namespace TRPO_labe_4
{
    class InsuranceСalculator
    {
        public double GetInsurance(IRealEstate estate)
        {
            double insurance = estate.Price;
            CalculateConstructionDate(estate, ref insurance);
            CalculateLivingSpace(estate, ref insurance);
            CalculateInsurancePeriod(estate, ref insurance);
            CalculateDepreciation(estate, ref insurance);
            CalculateNumberOfResidents(estate, ref insurance);
            insurance *= estate.HousingRatio;

            return insurance;
        }

        private void CalculateConstructionDate(IRealEstate estate, ref double insurance)
        {
            if (estate.ConstructionYear < 2000)
                insurance += (estate.Price / 5.2);
            else
                insurance += (estate.Price / 3.2);
        }

        private void CalculateLivingSpace(IRealEstate estate, ref double insurance)
        {
            if (estate.LivingSpace > 50 && estate.LivingSpace < 100)
                insurance += estate.Price / 1.91;
            if (estate.LivingSpace > 100)
                insurance += estate.Price / 1.81;
            else
                insurance += estate.Price / 1.71;
        }

        private void CalculateInsurancePeriod(IRealEstate estate, ref double insurance)
        {
            if (estate.InsurancePeriod > 2000)
                insurance += estate.Price / 3.2;
            else
                insurance += estate.Price / 5.31;
        }

        private void CalculateDepreciation(IRealEstate estate, ref double insurance)
        {
            if (estate.Depreciation > 10)
                insurance += estate.Price / 3.9;
            if (estate.Depreciation > 30)
                insurance += estate.Price / 3.3;
            if (estate.Depreciation > 50)
                insurance += estate.Price / 3;
        }

        private void CalculateNumberOfResidents(IRealEstate estate, ref double insurance)
        {
            if (estate.NumberOfResidents > 3)
                insurance += estate.Price / estate.NumberOfResidents;
            if (estate.NumberOfResidents == 1)
                insurance += estate.Price / 12.5;
        }
    }
}
