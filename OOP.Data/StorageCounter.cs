using System;
using System.Collections.Generic;

namespace OOP.Data;
    public class StorageCounter<T> : IStorage<T>
    {
        private readonly IStorage<T> _storage;
        public StorageCounter(IStorage<T> storage)
        {
            _storage = storage;
        }

        public List<T> Load()
        {
            List<T> data = _storage.Load();
            Console.WriteLine("Number of elements loaded: " + data.Count);

            return data;
        }

        public void Save(List<T> data)
        {
            _storage.Save(data);
            Console.WriteLine("Number of elements saved: " + data.Count);
        }
    }
