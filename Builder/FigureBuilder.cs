using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawFiguresLab.FiguresLR1;
using System.Windows;
using System.Reflection;

namespace DrawFiguresLab.Builder
{
    public static class FigureBuilder
    {
        public static ParentFigure Build(Type TypeofFigure, Point? point1, Point? point2)
        {
            ConstructorInfo fbuilder = TypeofFigure.GetConstructor(new[] { typeof(Point), typeof(Point) }); //get correct contructor

            return (ParentFigure)fbuilder.Invoke(new object[] { point1, point2 }); //create instance

        }

    }
}
