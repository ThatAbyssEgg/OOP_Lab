using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Data
{
    public abstract class FileStorage<T> : IStorage<T>
    {
        public readonly string Path;

        protected FileStorage(string path)
        {
            Path = path;
        }

        public abstract List<T> Load();

        public abstract void Save(List<T> data);
    }
}

