using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Paint.Model
{
    public class Triangle : Shape
    {
        public int Sides { get; set; } = 3;
        public double Radius { get; set; } = 0.0;

        public Triangle()
        {
            Type = "triangle";
        }

        public Triangle(string id, double x, double y, string stroke, int strokeWidth, bool draggable, double rotation, double scaleX, double scaleY, double skewX, string fill, double radius)
            : base(id, x, y, stroke, strokeWidth, draggable, rotation, scaleX, scaleY, skewX, fill)
        {
            Radius = radius;
            Type = "triangle";
            Sides = 3;
        }

        public bool CompareTo(Shape other)
        {
            if (other is not Triangle t) return false;
            return base.CompareTo(other) && t.Sides == this.Sides && Math.Abs(t.Radius - this.Radius) < 1e-18;
        }

        public new Triangle Clone()
        {
            return new Triangle(Id, X, Y, Stroke, StrokeWidth, Draggable, Rotation, ScaleX, ScaleY, SkewX, Fill, Radius);
        }

        public new string ToJson()
        {
            return JsonSerializer.Serialize(this, jsonOptions);
        }

        public new void FromJson(string json)
        {
            var shape = JsonSerializer.Deserialize<Triangle>(json, jsonOptions);
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
