using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P8ntR
{

    public class CustomRectangle : CustomShape
    {

        public double X
        {
            get { return Shape.Margin.Left; }
            set { Shape.Margin = new Thickness(value, Shape.Margin.Top, 0, 0); }
        }

        public double Y
        {
            get { return Shape.Margin.Top; }
            set { Shape.Margin = new Thickness(Shape.Margin.Left, value, 0, 0); }
        }

        public double Width
        {
            get { return Shape.Width; }
            set { Shape.Width = value; }
        }

        public double Height
        {
            get { return Shape.Height; }
            set { Shape.Height = value; }
        }

        public CustomRectangle()
        {
            Shape = new Rectangle();
        }

        public CustomRectangle(double x, double y, double width, double height, Brush fill, Brush stroke, double strokeThickness)
        {
            Shape = new Rectangle
            {
                Margin = new Thickness(x, y, 0, 0),
                Width = width,
                Height = height,
                Fill = fill,
                Stroke = stroke,
                StrokeThickness = strokeThickness
            };
        }
    }
}
