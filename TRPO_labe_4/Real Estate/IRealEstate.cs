using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_labe_4.Real_Estate
{
    interface IRealEstate
    {
        int InsurancePeriod { get; }
        double LivingSpace { get; }
        int NumberOfResidents { get; }
        int ConstructionYear { get; }
        double Depreciation { get; }
        double Price { get; }
        double HousingRatio { get; }
    }
}
