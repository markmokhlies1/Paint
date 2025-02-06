using Paint.Model;

namespace Paint.Controllers
{

    public class DemoService
    {
        private readonly ShapeManger _manger;

        public DemoService(ShapeManger manger)
        {
            _manger = manger;
        }

        public string Convert(string path)
        {
            string result = string.Empty;
            foreach (char c in path)
            {
                result += c == '*' ? '/' : c.ToString();
            }
            return result;
        }

        public bool SaveJson(string path)
        {
            return SaveLoad.SaveJSON(Convert(path));
        }

        public string[] LoadJson(string path)
        {
            Clear();
            return SaveLoad.LoadJSON(Convert(path));
        }

        public bool SaveXml(string path)
        {
            return SaveLoad.SaveXML(Convert(path));
        }

        public string[] LoadXml(string path)
        {
            Clear();
            return SaveLoad.LoadXML(Convert(path));
        }

        public string Create(string type, string json)
        {
            var shape = _manger.CreateShape(type, json);
            model.AddElement(shape);
            Undo_Redo.Add(shape);
            return shape.ToJson();
        }

        public string Update(string id, string json)
        {
            var shape = model.GetShape(id);
            Undo_Redo.Add(_manger.CreateShape(shape.GetType(), shape.ToJson()));
            shape.FromJson(json);
            model.AddElement(shape);
            return shape.ToJson();
        }

        public void Delete(string id)
        {
            Undo_Redo.Add(model.GetShape(id));
            model.Delete(id);
        }

        public string Undo()
        {
            return Undo_Redo.Undo();
        }

        public string Redo()
        {
            return Undo_Redo.Redo();
        }

        public void Clear()
        {
            model.Clear();
            Undo_Redo.st1.Clear();
            Undo_Redo.st2.Clear();
        }

        public Dictionary<string, Shape> Print()
        {
            return model.GetDataBase();
        }
    }

}
