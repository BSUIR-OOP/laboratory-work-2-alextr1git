using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FiguresLab.Modules
{
    public class Draw
    {
        Graphics graphic;
        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 5); //set color and width
        int[] array = new int[4];

        public Draw(int x1, int y1, int x2, int y2, Graphics graphics)
        {
            graphic = graphics;

            this.array[0] = x1;
            this.array[1] = y1;
            this.array[2] = x2;
            this.array[3] = y2;
        }

        public void PrintFigure(IDraw display)
        {
            display.Make(array, pen, graphic);
        }
    }

    public interface IDraw
    {
        void Make(int[] array, Pen pen, Graphics graphics);
    }

    class DrawLine : IDraw
    {
        public void Make(int[] array, Pen pen, Graphics graphics)
        {
            Point a = new Point(array[0], array[1]);
            Point b = new Point(array[2], array[3]);

            graphics.DrawLine(pen, a, b);
        }
    }
    class DrawEllipse : IDraw
    {
        public void Make(int[] array, Pen pen, Graphics graphics)
        {
            int width = array[2] - array[0];
            int height = array[3] - array[1];

            graphics.DrawEllipse(pen, array[0], array[1], width, height);
        }
    }

    class DrawCircle : IDraw
    {
        public void Make(int[] array, Pen pen, Graphics graphics)
        {
            if ((array[0] != array[2]) && (array[1] != array[3]))
                graphics.DrawArc(pen, array[0], array[1], (float)Math.Sqrt(Math.Pow(Math.Abs(array[2] - array[0]), 2) + Math.Pow(Math.Abs(array[3] - array[1]), 2)), (float)Math.Sqrt(Math.Pow(Math.Abs(array[2] - array[0]), 2) + Math.Pow(Math.Abs(array[3] - array[1]), 2)), 0, 360);
        }

    }

    class DrawRectangle : IDraw
    {

        public void Make(int[] array, Pen pen, Graphics graphics)
        {
            int width = array[2] - array[0];
            int height = array[3] - array[1];

            graphics.DrawRectangle(pen,array[0],array[1],width,height);
        }
    }

    class DrawTriangle : IDraw
    {
        public void Make(int[] array, Pen pen, Graphics graphics)
        {
            Point a = new Point((array[2] + array[0]) / 2, array[1]);
            Point b = new Point(array[0], array[3]);
            Point c = new Point(array[2], array[3]);

            graphics.DrawLine(pen, a, b);
            graphics.DrawLine(pen, b, c);
            graphics.DrawLine(pen, c, a);
        }
    }

    class DrawRhombus : IDraw
    {
        public void Make(int[] array, Pen pen, Graphics graphics)
        {
            Point a = new Point((array[2] + array[0]) / 2, array[1]);
            Point b = new Point(array[2], (array[3] + array[1]) / 2);
            Point c = new Point((array[2] + array[0]) / 2, array[3]);
            Point d = new Point(array[0], (array[3] + array[1]) / 2);

            graphics.DrawLine(pen, a, b);
            graphics.DrawLine(pen, b, c);
            graphics.DrawLine(pen, c, d);
            graphics.DrawLine(pen, d, a);
        }
    }

    class DrawHexagon : IDraw
    {
        public void Make(int[] array, Pen pen, Graphics graphics)
        {
            Point a = new Point((array[2] + array[0]) / 2, array[1]);
            Point b = new Point(array[2], array[1] + (Math.Abs(array[1] - array[3]) / 3));
            Point c = new Point(array[2], array[3] - (Math.Abs(array[1] - array[3]) / 3));
            Point d = new Point((array[2] + array[0]) / 2, array[3]);
            Point e = new Point(array[0], array[3] - (Math.Abs(array[1] - array[3]) / 3));
            Point f = new Point(array[0], array[1] + (Math.Abs(array[1] - array[3]) / 3));

            graphics.DrawLine(pen, a, b);
            graphics.DrawLine(pen, b, c);
            graphics.DrawLine(pen, c, d);
            graphics.DrawLine(pen, d, e);
            graphics.DrawLine(pen, e, f);
            graphics.DrawLine(pen, f, a);
        }
    }

}
