using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Data
{
    public class StorageArchiver<T> : IStorage<T>
    {
        private readonly FileStorage<T> _storage;
        private readonly string _pathToArchive;

        public StorageArchiver(FileStorage<T> storage, string pathToArchive)
        {
            _storage = storage;
            _pathToArchive = pathToArchive;
        }

        public List<T> Load()
        {
            // Разархивируем входящий файл
            return _storage.Load(); 
        }

        public void Save(List<T> data)
        {
            _storage.Save(data);
            using (FileStream zipToOpen = new FileStream(_pathToArchive, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry readmeEntry = archive.CreateEntry(Path.GetFileName(_storage.Path));
                    using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                    {
                        using (FileStream stream = new FileStream(_storage.Path, FileMode.Open))
                        {
                            writer.Write(stream);
                        }
                    }
                }
            }
        }
    }
}
