using System;

namespace OOP_Lab_1
{
    [Serializable]
    public class MediumRoyality:LowerRoyality
    {
        public MediumRoyality()
            : base()
        {
        }

        public MediumRoyality(string preloadedRoyalName, string preloadedRoyalRank, int preloadedRoyalAge)
            : base(preloadedRoyalName, preloadedRoyalRank, preloadedRoyalAge)
        {
        }

        public override void Introduce()
        {
            Console.WriteLine("Your Mightness, " + Name + ", " + RankName + " of this land, you are serving us well for almost " + Age + " years of your life. It is surely a pleasure to talk to you.");
        }

        protected override string GetTitle()
        {
            return "medium";
        }
    }
}
