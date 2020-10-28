using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TRPO_labe_3.Interfaces;
using TRPO_labe_3.Utilities;

namespace TRPO_labe_3.Classes.Models
{
    public class FigureRandomer
    {
        private Random rnd;
        private IFactory factory;

        public FigureRandomer()
        {
            rnd = new Random();
        }

        public List<IFigure> GetFigures()
        {
            List<IFigure> figures = new List<IFigure>();
            for (int i = 0; i < 10; i++)
            {
                int figureSize = rnd.Next(0, 2);
                int type = rnd.Next(0, 7);
                Color color = Color.FromRgb((byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256));
                IFigure figure = CreateOne(figureSize, type, color);
                figures.Add(figure);
            }

            return figures;
        }

        private IFigure CreateOne(int size, int type, Color color)
        {
            if (size == 0)
                factory = new ClassicFigureFactory();
            else
                factory = new BigFigureFactory();

            IFigure figure = factory.Create();
            figure.Color = color;
            figure.Type = (FigureType)Enum.GetValues(typeof(FigureType)).GetValue(type);
            return figure;
        }
    }
}
