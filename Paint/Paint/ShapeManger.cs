using Paint.Model;

namespace Paint
{
    public class ShapeManger
    {
        private Dictionary<string, Shape> map = new Dictionary<string, Shape>();
        private ShapeFactory factory = new ShapeFactory();

        public Shape CreateShape(string type, string json)
        {
            if (!map.ContainsKey(type))
            {
                map[type] = factory.CreateShape(type);
            }

            Shape shape = (Shape)map[type].Clone();
            shape.FromJson(json);
            return shape;
        }
    }
}
