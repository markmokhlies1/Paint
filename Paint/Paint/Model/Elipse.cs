using System.Text.Json;

namespace Paint.Model
{
    public class Elipse : Shape
    {
        public double RadiusX { get; set; } = 0.0;
        public double RadiusY { get; set; } = 0.0;

        public Elipse()
        {
            Type = "elipse";
        }

        public Elipse(string id, double x, double y, string stroke, int strokeWidth, bool draggable, double rotation, double scaleX, double scaleY, double skewX, string fill, double radiusX, double radiusY)
            : base(id, x, y, stroke, strokeWidth, draggable, rotation, scaleX, scaleY, skewX, fill)
        {
            RadiusX = radiusX;
            RadiusY = radiusY;
            Type = "elipse";
        }

        public bool CompareTo(Shape other)
        {
            if (other is not Elipse e) return false;
            return base.CompareTo(other) && Math.Abs(e.RadiusX - this.RadiusX) < 1e-18 && Math.Abs(e.RadiusY - this.RadiusY) < 1e-18;
        }

        public new Elipse Clone()
        {
            return new Elipse(Id, X, Y, Stroke, StrokeWidth, Draggable, Rotation, ScaleX, ScaleY, SkewX, Fill, RadiusX, RadiusY);
        }

        public new string ToJson()
        {
            return JsonSerializer.Serialize(this, jsonOptions);
        }

        public new void FromJson(string json)
        {
            var shape = JsonSerializer.Deserialize<Elipse>(json, jsonOptions);
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
                RadiusX = shape.RadiusX;
                RadiusY = shape.RadiusY;
            }
        }
    }
}
