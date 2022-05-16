using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Data
{
    public interface IStorage<T>
    {
        public void Save(List<T> data);

        public List<T> Load();
    }
}
