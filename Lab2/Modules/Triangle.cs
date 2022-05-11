﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FiguresLab.Modules
{
    class Triangle : Figure
    {
        public Graphics graphic;
        public Triangle(int x1, int y1, int x2, int y2, Graphics graphic) : base(x1, y1, x2, y2)
        {
            this.graphic = graphic;
        }

        public override void DrawFigure()
        {
            Draw draw = new Draw(x1, y1, x2, y2, graphic);
            draw.PrintFigure(new DrawTriangle());
        }
    }
}
