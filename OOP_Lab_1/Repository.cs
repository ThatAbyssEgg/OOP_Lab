using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.Data;

namespace OOP_Lab_1
{
    public class Repository
    {
        private readonly IStorage<LowerRoyality> _storage;

        public Repository(IStorage<LowerRoyality> storage)
        {
            _storage = storage;
        }

        // Get all
        public List<LowerRoyality> GetAll()
        {
            return _storage.Load();
        }

        // Add
        public void Add(LowerRoyality royality)
        {
            List<LowerRoyality> data = _storage.Load();
            data.Add(royality);
            _storage.Save(data);
        }

        // Delete
        public void Delete(string name)
        {
            List<LowerRoyality> data = _storage.Load();
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Name == name)
                {
                    data.RemoveAt(i);
                    break;
                }
            }
           _storage.Save(data);
        }

        // Update
        public void Update(string name, string newName, string rank, int age)
        {
            List<LowerRoyality> data = _storage.Load();
            for (int i = 0; i < data.Count; i++)
            {
                if (name == data[i].Name)
                {
                    data[i].Name = newName;
                    data[i].Age = age;
                    data[i].RankName = rank;
                    break;
                }
            }
            _storage.Save(data);
        }
    }
}
