using System.Windows.Media;
using TRPO_labe_3.Utilities;

namespace TRPO_labe_3.Interfaces
{
    public interface IFigure
    {
        FigureType Type { get; set; } 
        Color Color { get; set; }
        bool IsFigureBig { get; set; }
    }
}
