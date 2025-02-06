using Paint.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Paint
{
    [Serializable]
    public class SaveLoad
    {
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        public static bool SaveJSON(string path)
        {
            string json = JsonSerializer.Serialize(model.GetDataBase(), jsonOptions);
            File.WriteAllText(path, json);
            return true;
        }

        public static string[] LoadJSON(string path)
        {
            string json = File.ReadAllText(path);
            model.FromJson(json);
            return GetShapesList();
        }

        public static bool SaveXML(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Dictionary<string, Shape>));
            using (TextWriter writer = new StreamWriter(path))
            {
                xmlSerializer.Serialize(writer, model.GetDataBase());
            }
            return true;
        }

        public static string[] LoadXML(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Dictionary<string, Shape>));
            using (TextReader reader = new StreamReader(path))
            {
                model.SetDataBase((Dictionary<string, Shape>)xmlSerializer.Deserialize(reader));
            }
            return GetShapesList();
        }

        private static string[] GetShapesList()
        {
            var list = new List<string>();
            foreach (var shape in model.GetDataBase().Values)
            {
                list.Add(JsonSerializer.Serialize(shape, jsonOptions));
            }
            return list.ToArray();
        }
    }

}
