using System.Text.Json;

namespace Paint.Model
{
    public class Circle : Shape
    {
        public double Radius { get; set; } = 0.0;

        public Circle()
        {
            Type = "circle";
        }

        public Circle(string id, double x, double y, string stroke, int strokeWidth, bool draggable, double rotation, double scaleX, double scaleY, double skewX, string fill, double radius)
            : base(id, x, y, stroke, strokeWidth, draggable, rotation, scaleX, scaleY, skewX, fill)
        {
            Radius = radius;
            Type = "circle";
        }

        public bool CompareTo(Shape other)
        {
            if (other is not Circle ci) return false;
            return base.CompareTo(other) && Math.Abs(this.Radius - ci.Radius) < 1e-18;
        }

        public new Circle Clone()
        {
            return new Circle(Id, X, Y, Stroke, StrokeWidth, Draggable, Rotation, ScaleX, ScaleY, SkewX, Fill, Radius);
        }

        public new string ToJson()
        {
            return JsonSerializer.Serialize(this, jsonOptions);
        }

        public new void FromJson(string json)
        {
            var shape = JsonSerializer.Deserialize<Circle>(json, jsonOptions);
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
                Radius = shape.Radius;
            }
        }
    }
}
