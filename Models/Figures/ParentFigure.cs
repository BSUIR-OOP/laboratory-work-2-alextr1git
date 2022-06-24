using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace DrawFiguresLab.FiguresLR1
{
    public abstract class ParentFigure
    {
        public abstract void drawCanvas(Canvas canvas);

        public static System.Windows.Shapes.Line drawLine(int x1, int x2, int y1, int y2)
        {
            var NewLine = new System.Windows.Shapes.Line();
            NewLine.Stroke = System.Windows.Media.Brushes.Black;

            NewLine.X1 = x1;
            NewLine.X2 = x2;

            NewLine.Y1 = y1;
            NewLine.Y2 = y2;

            NewLine.HorizontalAlignment = HorizontalAlignment.Left;
            NewLine.VerticalAlignment = VerticalAlignment.Center;

            NewLine.StrokeThickness = 3;

            return NewLine;
        }

    }
}
