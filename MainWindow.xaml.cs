using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DrawFiguresLab.FiguresLR1;
using DrawFiguresLab.Builder;


namespace DrawFiguresLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button buttonactive;

        private Point pointright;

        private Point pointleft;

        public MainWindow()
        {
            InitializeComponent();

            var ListOfFigures = new List<FiguresLR1.ParentFigure>();
            IEnumerable<Type> TypesOfShapes = typeof(FiguresLR1.ParentFigure).Assembly.ExportedTypes.Where(t => typeof(FiguresLR1.ParentFigure).IsAssignableFrom(t) && t != typeof(FiguresLR1.ParentFigure));

            foreach (var member in TypesOfShapes)
            {
                Button buttonelement = new Button()
                {
                    Margin = new Thickness(2),
                    Content = member.Name,

                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,

                    Width = 200,
                    Height = 50,

                    Tag = member
                };

                buttonelement.Click += ChooseFigure;

                DockPanel.SetDock(buttonelement, Dock.Top);
                toolPanel.Children.Add(buttonelement);
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var Coordinates = e.GetPosition(this.DrawFieldCanvas);

            if (buttonactive == null)
                return;

            else if (pointleft.X == 0)
                pointleft = new Point((int)Coordinates.X, (int)Coordinates.Y);

            else
            {
                pointright = new Point((int)Coordinates.X, (int)Coordinates.Y);
                ParentFigure Figure = FigureBuilder.Build((Type)buttonactive.Tag, pointright, pointleft);
                
                Figure.drawCanvas(DrawFieldCanvas);//figure drawing
                
                pointright.X = pointleft.X = 0;
                pointright.Y = pointleft.Y = 0;
            }
        }

        private void ChooseFigure(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (buttonactive != null) buttonactive.IsEnabled = true;
            
            buttonactive = button;

            buttonactive.IsEnabled = false;
        }
    }
}
