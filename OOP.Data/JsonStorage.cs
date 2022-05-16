using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OOP.Data
{
    public class JsonStorage<T> : FileStorage<T>
    {
        public JsonStorage(string path) : base(path)
        {
        }
        public override List<T> Load()
        {
            var options = new JsonSerializerOptions { IncludeFields = true };
            using (FileStream r = new FileStream(Path, FileMode.Open))
            {
                return JsonSerializer.Deserialize<List<T>>(r, options);
            }
        }
        
        public override void Save(List<T> data)
        {
            var options = new JsonSerializerOptions { IncludeFields = true };
            string json = JsonSerializer.Serialize<List<T>>(data, options);
            using (StreamWriter w = new StreamWriter(Path))
            {
                w.WriteLine(json);
            }
        }
    }
}
