using Paint.Model;
using System.Text.Json;
namespace Paint
{
    [Serializable]
    public class model
    {
        private static Dictionary<string, Shape> dataBase = new Dictionary<string, Shape>();
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        public static string ToJson()
        {
            return JsonSerializer.Serialize(dataBase, jsonOptions);
        }

        public static void FromJson(string json)
        {
            dataBase = JsonSerializer.Deserialize<Dictionary<string, Shape>>(json, jsonOptions) ?? new Dictionary<string, Shape>();
        }

        public static void AddElement(Shape shape)
        {
            if (dataBase.ContainsKey(shape.Id))
            {
                dataBase[shape.Id] = shape;
            }
            else
            {
                dataBase.Add(shape.Id, shape);
            }
        }

        public static Shape GetShape(string id)
        {
            return dataBase.TryGetValue(id, out var shape) ? shape : null;
        }

        public static bool ContainShape(string id)
        {
            return dataBase.ContainsKey(id);
        }

        public static Dictionary<string, Shape> GetDataBase()
        {
            return dataBase;
        }

        public static void Delete(string id)
        {
            dataBase.Remove(id);
        }

        public static void SetDataBase(Dictionary<string, Shape> newDataBase)
        {
            dataBase = newDataBase;
        }

        public static void Clear()
        {
            dataBase.Clear();
        }
    }
}
