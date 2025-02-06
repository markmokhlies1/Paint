using System.Text.Json;

namespace Paint.Model
{
    [Serializable]
    public class Shape : ICloneable
    {
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        public string Id { get; set; } = "";
        public double X { get; set; } = 0.0;
        public double Y { get; set; } = 0.0;
        public string Stroke { get; set; } = "";
        public int StrokeWidth { get; set; } = 0;
        public bool Draggable { get; set; } = false;
        public double Rotation { get; set; } = 0.0;
        public double ScaleX { get; set; } = 1.0;
        public double ScaleY { get; set; } = 1.0;
        public double SkewX { get; set; } = 0.0;
        public string Type { get; set; } = "circle";
        public string Fill { get; set; } = "";

        public Shape() { }

        public Shape(string id, double x, double y, string stroke, int strokeWidth, bool draggable, double rotation, double scaleX, double scaleY, double skewX, string fill)
        {
            Id = id;
            X = x;
            Y = y;
            Stroke = stroke;
            StrokeWidth = strokeWidth;
            Draggable = draggable;
            Rotation = rotation;
            ScaleX = scaleX;
            ScaleY = scaleY;
            SkewX = skewX;
            Fill = fill;
        }

        public bool CompareTo(Shape other)
        {
            if (other == null) return false;

            return other.Fill == this.Fill &&
                   Math.Abs(this.X - other.X) < 1e-18 &&
                   Math.Abs(this.Y - other.Y) < 1e-18 &&
                   Math.Abs(this.Rotation - other.Rotation) < 1e-18 &&
                   Math.Abs(this.ScaleX - other.ScaleX) < 1e-18 &&
                   Math.Abs(this.ScaleY - other.ScaleY) < 1e-18 &&
                   Math.Abs(this.SkewX - other.SkewX) < 1e-18 &&
                   this.Id == other.Id;
        }

        public object Clone()
        {
            return new Shape(Id, X, Y, Stroke, StrokeWidth, Draggable, Rotation, ScaleX, ScaleY, SkewX, Fill);
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, jsonOptions);
        }

        public void FromJson(string json)
        {
            var shape = JsonSerializer.Deserialize<Shape>(json, jsonOptions);
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
            }
        }

        public override string ToString()
        {
            return $"Shapes{{ Id='{Id}', X={X}, Y={Y}, Stroke='{Stroke}', StrokeWidth={StrokeWidth}, Draggable={Draggable}, Rotation={Rotation}, ScaleX={ScaleX}, ScaleY={ScaleY}, SkewX={SkewX}, Type='{Type}', Fill='{Fill}' }}";
        }
    }
}
