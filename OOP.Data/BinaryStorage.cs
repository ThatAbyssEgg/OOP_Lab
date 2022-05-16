using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Data
{
    public class BinaryStorage<T> : FileStorage<T>
    {
        public BinaryStorage(string path) : base(path)
        {
        }

        public override List<T> Load()
        {
            using (Stream file = File.Open(Path, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();

                object obj = bf.Deserialize(file);

                return obj as List<T>;
            }
        }

        public override void Save(List<T> data)
        {
            using (Stream file = File.Open(Path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, data);
            }
        }
    }
}
