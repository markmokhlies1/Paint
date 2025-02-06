using Paint.Model;

namespace Paint
{
    public class ShapeFactory
    {
        public Shape CreateShape(string type)
        {
            return type switch
            {
                "circle" => new Circle(),
                "line" => new Line(),
                "square" => new Square(),
                "triangle" => new Triangle(),
                "elipse" => new Elipse(),
                "rectangle" => new Rectangle(),
                _ => null
            };
        }
    }
}
