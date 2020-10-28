using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_3.Interfaces;

namespace TRPO_labe_3.Classes.Abstract
{
    abstract class FigureFactory : IFactory
    {
        public abstract IFigure Create();
    }
}
