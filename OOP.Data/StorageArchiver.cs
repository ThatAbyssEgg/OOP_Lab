using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

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
            using (ZipArchive archive = ZipFile.OpenRead(_pathToArchive))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.Equals(Path.GetFileName(_storage.Path)))
                    {
                        entry.ExtractToFile(_storage.Path, true);
                        break;
                    }
                }
            }

            return _storage.Load(); 
        }

        public void Save(List<T> data)
        {
            _storage.Save(data);

            // Read data file to string
            using FileStream stream = new FileStream(_storage.Path, FileMode.Open);
            using StreamReader streamReader = new StreamReader(stream);
            string fileData = streamReader.ReadToEnd();

            // Create archive
            using FileStream zipToOpen = new FileStream(_pathToArchive, FileMode.Create);
            using ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update);

            // Create archived file
            ZipArchiveEntry readmeEntry = archive.CreateEntry(Path.GetFileName(_storage.Path));

            // Write data to archived file as string
            using StreamWriter writer = new StreamWriter(readmeEntry.Open());

            writer.Write(fileData);
        }
    }
}
