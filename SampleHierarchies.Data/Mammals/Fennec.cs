using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Mammals
{
    public class Fennec : MammalBase, IFennec
    {
        #region Public Methods

        public override void Display()
        {
            Console.WriteLine($"My name is: {Name}, my age is: {Age}. I have {CoatPattern} fur. I can run at a speed of {RunningSpeed} kilometers per hour.");
        }

        public override void Copy(IAnimal animal)
        {
            if (animal is IFennec fennec)
            {
                base.Copy(animal);
                EarSize = fennec.EarSize;
                CoatPattern = fennec.CoatPattern;
                TailLength = fennec.TailLength;
                DietaryHabits = fennec.DietaryHabits;
                RunningSpeed = fennec.RunningSpeed;
            }
        }

        #endregion

        #region Ctors And Properties

        public double EarSize { get; set; }
        public string CoatPattern { get; set; }
        public double TailLength { get; set; }
        public string DietaryHabits { get; set; }
        public double RunningSpeed { get; set; }

        public Fennec(string name, int age, double earSize, string coatPattern, double tailLength, string dietaryHabits, double runningSpeed)
            : base(name, age, MammalSpecies.Fennec)
        {
            EarSize = earSize;
            CoatPattern = coatPattern;
            TailLength = tailLength;
            DietaryHabits = dietaryHabits;
            RunningSpeed = runningSpeed;
        }

        #endregion
    }

}
