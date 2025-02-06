using System.Text.Json;

namespace Paint.Model
{
    public class Rectangle : Shape
    {
        public double Height { get; set; } = 0.0;
        public double Width { get; set; } = 0.0;

        public Rectangle()
        {
            Type = "rectangle";
        }

        public Rectangle(string id, double x, double y, string stroke, int strokeWidth, bool draggable, double rotation, double scaleX, double scaleY, double skewX, string fill, double height, double width)
            : base(id, x, y, stroke, strokeWidth, draggable, rotation, scaleX, scaleY, skewX, fill)
        {
            Height = height;
            Width = width;
            Type = "rectangle";
        }

        public bool CompareTo(Shape other)
        {
            if (other is not Rectangle rec) return false;
            return base.CompareTo(other) && Math.Abs(rec.Height - this.Height) < 1e-18 && Math.Abs(rec.Width - this.Width) < 1e-18;
        }

        public new Rectangle Clone()
        {
            return new Rectangle(Id, X, Y, Stroke, StrokeWidth, Draggable, Rotation, ScaleX, ScaleY, SkewX, Fill, Height, Width);
        }

        public new string ToJson()
        {
            return JsonSerializer.Serialize(this, jsonOptions);
        }

        public new void FromJson(string json)
        {
            var shape = JsonSerializer.Deserialize<Rectangle>(json, jsonOptions);
            if (shape != null)
            {
                Id = shape.Id;
                X = shape.X;
                Y = shape.Y;
                Stroke = shape.Stroke;
                StrokeWidth = shape.StrokeWidth;
                Draggable = shape.Draggable;
                Rotation = shape.Rotation;
                ScaleX = shape.ScaleX;
                ScaleY = shape.ScaleY;
                SkewX = shape.SkewX;
                Fill = shape.Fill;
                Height = shape.Height;
                Width = shape.Width;
            }
        }
    }
}
