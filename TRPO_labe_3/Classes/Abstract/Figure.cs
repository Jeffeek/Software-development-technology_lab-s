using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TRPO_labe_3.Interfaces;
using TRPO_labe_3.Utilities;

namespace TRPO_labe_3.Classes.Abstract
{
    public abstract class Figure : IFigure
    {
        public FigureType Type { get; set; }
        public Color Color { get; set; }
        public bool IsFigureBig { get; set; }

        public override string ToString()
        {
            return $"{nameof(Type)}: {Type}, {nameof(Color)}: {Color}, {nameof(IsFigureBig)}: {IsFigureBig}";
        }
    }
}
