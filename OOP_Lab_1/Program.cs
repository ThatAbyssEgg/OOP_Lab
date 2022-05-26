using System;
using System.Collections.Generic;
using OOP.Data;

namespace OOP_Lab_1
{
    public class Program
    {
        private static void InputActionCase(int inputAction, Repository repository)
        {
            switch (inputAction)
            {
                case 1:
                    Console.WriteLine("Enter the name of the royal:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the royal's rank:");
                    string rank = Console.ReadLine();
                    Console.WriteLine("Enter the royal's age:");
                    int age = Convert.ToInt32(Console.ReadLine());
                    repository.Add(new LowerRoyality(name, rank, age));
                    break;
                    
                case 2:
                    Console.WriteLine("Enter the name of a royal to delete:");
                    name = Console.ReadLine();
                    repository.Delete(name);
                    break;

                case 3:
                    Console.WriteLine("Enter the name of the royal to edit:");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter the NEW name of the royal:");
                    string newName = Console.ReadLine();
                    Console.WriteLine("Enter the NEW royal's rank:");
                    rank = Console.ReadLine();
                    Console.WriteLine("Enter the NEW royal's age:");
                    age = Convert.ToInt32(Console.ReadLine());
                    repository.Update(name, newName, rank, age);
                    break;

                case 4:
                    List<LowerRoyality> royalities = repository.GetAll();
                    for (int i = 0; i < royalities.Count; i++)
                    {
                        royalities[i].Introduce();
                    }
                    break;
            }
        }
        public static void Main()
        { 
            Console.WriteLine("Choose the file you want to use");
            Console.WriteLine("1: JSON");
            Console.WriteLine("2: Binary");

            int inputFile = Console.ReadKey().KeyChar - 48;
            Console.WriteLine();

            Console.WriteLine("Choose the action");
            Console.WriteLine("1: Add");
            Console.WriteLine("2: Delete");
            Console.WriteLine("3: Update");
            Console.WriteLine("4: Show all");
            
            int inputAction = Console.ReadKey().KeyChar - 48;
            Console.WriteLine();

            switch(inputFile)
            {
                case 1:
                    JsonStorage<LowerRoyality> jsonStorage = new JsonStorage<LowerRoyality>(@"F:\Projects\OOP_Lab\data.json");
                    Repository repository = new Repository(new StorageArchiver<LowerRoyality>(jsonStorage, @"F:\Projects\OOP_Lab\data.zip"));
                    InputActionCase(inputAction, repository);
                    break;

                case 2:
                    BinaryStorage<LowerRoyality> binaryStorage = new BinaryStorage<LowerRoyality>(@"F:\Projects\OOP_Lab\data.dat");
                    repository = new Repository(binaryStorage);
                    InputActionCase(inputAction, repository);
                    break;
            }
        }
    }
}
