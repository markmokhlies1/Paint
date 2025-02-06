using Paint.Model;
namespace Paint
{
    public class Undo_Redo
    {
        private static Stack<Shape> st1 = new Stack<Shape>();
        private static Stack<Shape> st2 = new Stack<Shape>();

        private static ShapeManger manager = new ShapeManger();

        public static void Add(Shape s)
        {
            st2.Clear();
            st1.Push(s);
        }

        public static string Undo()
        {
            if (st1.Count == 0)
                return "NON";

            Shape y = st1.Pop();
            string ff = y.Id;

            if (model.ContainShape(ff))
            {
                Shape z = model.GetShape(ff);
                if (y.CompareTo(z))
                {
                    model.Delete(ff);
                    st2.Push(y);
                    return y.Id + "delete";
                }
                else
                {
                    st2.Push(z);
                    model.AddElement(y);
                    return y.Id + Undo_Redo.KonvaJson(y);
                }
            }
            else
            {
                model.AddElement(y);
                return y.Id + Undo_Redo.KonvaJson(y);
            }
        }

        public static string Redo()
        {
            if (st2.Count == 0)
                return "NON";

            Shape sh = model.GetShape(st2.Peek().Id) ?? st2.Peek();
            Shape shape = manager.CreateShape(st2.Peek().GetType(), sh.ToJson());
            st1.Push(shape);
            model.AddElement(st2.Peek());
            st2.Pop();
            return st1.Peek().Id + Undo_Redo.KonvaJson(model.GetShape(st1.Peek().Id));
        }

        public static string KonvaJson(Shape shape)
        {
            string json = shape.ToJson();
            for (int i = 6; i < json.Length; i++)
            {
                if (json[i] == '\"' && json[i - 1] == ':' && json[i - 2] == '\"' && json[i - 3] == 'l' && json[i - 4] == 'l' && json[i - 5] == 'i' && json[i - 6] == 'f')
                {
                    json = json.Substring(0, i + 1) + "#" + json.Substring(i + 1);
                    break;
                }
            }

            string className = shape.GetType() switch
            {
                "rectangle" => "Rect",
                "circle" => "Circle",
                "line" => "Line",
                "ellipse" => "Ellipse",
                "triangle" => "RegularPolygon",
                "square" => "Rect",
                _ => ""
            };

            json = "{\"attrs\":" + json + ",\"className\":\"" + className + "\"}";
            return json;
        }
    }
}
