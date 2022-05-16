using System;

namespace OOP_Lab_1
{
    [Serializable]
    public class HigherRoyality:MediumRoyality
    {
        public HigherRoyality()
            : base()
        {
        }

        public HigherRoyality(string preloadedRoyalName, string preloadedRoyalRank, int preloadedRoyalAge) 
            : base(preloadedRoyalName, preloadedRoyalRank, preloadedRoyalAge)
        {
        }

        public override void Introduce()
        { 
            Console.WriteLine("I speak to you by the will of " + Name + ", the " + RankName + " of the lands around us, who was destined to rule this land since they were born " + Age + " years ago!");
        }

        protected override string GetTitle()
        {
            return "higher";
        }
    }
}
