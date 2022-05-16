using System;

namespace OOP_Lab_1
{
    [Serializable]
    public class LowerRoyality
    {
        public string Name;
        public string RankName;
        public int Age;

        public LowerRoyality()
        {
            //Console.WriteLine($"Input the {GetTitle()} royal's name");
            //Name = Console.ReadLine();
            //Console.WriteLine($"Input the {GetTitle()} royal's rank name");
            //RankName = Console.ReadLine();
            //Console.WriteLine($"Input the {GetTitle()} royal's age");
            //Age = Convert.ToInt32(Console.ReadLine());
        }

        public LowerRoyality(string preloadedRoyalName, string preloadedRoyalRank, int preloadedRoyalAge)
        {
            Name = preloadedRoyalName;
            RankName = preloadedRoyalRank;
            Age = preloadedRoyalAge;
        }

        protected virtual string GetTitle()
        {
            return "lower";
        }

        public virtual void Introduce()
        {
            Console.WriteLine("This honorable aristocrat " + Name + " that have been with us for " + Age + " years is a " + RankName);
        }
    }
}
