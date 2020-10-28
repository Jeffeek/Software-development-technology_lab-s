using TRPO_labe_3.Classes.Abstract;
using TRPO_labe_3.Interfaces;

namespace TRPO_labe_3.Classes.Models
{
    class BigFigureFactory : FigureFactory
    {
        public override IFigure Create()
        {
            return new BigFigure();
        }
    }
}
