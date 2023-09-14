using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Mammals
{
    public class Sloth : MammalBase, ISloth
    {
        #region Public Methods

        public override void Display()
        {
            Console.WriteLine($"My name is: {Name}, my age is: {Age}. I have {FurColor} fur. I can climb at a speed of {ClimbingSpeed} meters per second.");
        }

        public override void Copy(IAnimal animal)
        {
            if (animal is ISloth sloth)
            {
                base.Copy(animal);
                FurColor = sloth.FurColor;
                Diet = sloth.Diet;
                ClimbingSpeed = sloth.ClimbingSpeed;
                DailyActivityHours = sloth.DailyActivityHours;
            }
        }

        #endregion

        #region Ctors And Properties

        public string FurColor { get; set; }
        public string Diet { get; set; }
        public double ClimbingSpeed { get; set; }
        public int DailyActivityHours { get; set; }
        public int SleepingTime { get; set; }

        public Sloth(string name, int age, string furColor, string diet, double climbingSpeed, int dailyActivityHours, int sleepingTime) : base(name, age, MammalSpecies.Sloth)
        {
            FurColor = furColor;
            Diet = diet;
            ClimbingSpeed = climbingSpeed;
            DailyActivityHours = dailyActivityHours;
            SleepingTime = sleepingTime;
        }

        #endregion
    }
}
