using System.Text.Json;

namespace Paint.Model
{
    public class Square : Shape
    {
        public double Height { get; set; } = 0.0;
        public double Width { get; set; } = 0.0;

        public Square()
        {
            Type = "square";
        }

        public Square(string id, double x, double y, string stroke, int strokeWidth, bool draggable, double rotation, double scaleX, double scaleY, double skewX, string fill, double height, double width)
            : base(id, x, y, stroke, strokeWidth, draggable, rotation, scaleX, scaleY, skewX, fill)
        {
            Height = height;
            Width = width;
            Type = "square";
        }

        public bool CompareTo(Shape other)
        {
            if (other is not Square rec) return false;
            return base.CompareTo(other) && Math.Abs(rec.Height - this.Height) < 1e-18 && Math.Abs(rec.Width - this.Width) < 1e-18;
        }

        public new Square Clone()
        {
            return new Square(Id, X, Y, Stroke, StrokeWidth, Draggable, Rotation, ScaleX, ScaleY, SkewX, Fill, Height, Width);
        }

        public new string ToJson()
        {
            return JsonSerializer.Serialize(this, jsonOptions);
        }

        public new void FromJson(string json)
        {
            var shape = JsonSerializer.Deserialize<Square>(json, jsonOptions);
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
