using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FiguresLab.Modules
{
    internal class FigureCollection
    {
        public List<Figure> figures;

        public FigureCollection(int x1, int y1, int x2, int y2, Graphics graphics)
        {
            figures = new List<Figure>()
            {
                new Line(x1, y1, x2, y2, graphics),
                new Triangle(x1, y1, x2, y2, graphics),
                new Ellipse(x1, y1, x2, y2, graphics),
                new Rectangle(x1, y1, x2, y2, graphics),
                new Hexagon(x1, y1, x2, y2, graphics),
                new Rhombus(x1, y1, x2, y2, graphics),
                new Circle(x1, y1, x2, y2, graphics),
               
                
            };
        }
        public FigureCollection()
        {

        }

    }
}
