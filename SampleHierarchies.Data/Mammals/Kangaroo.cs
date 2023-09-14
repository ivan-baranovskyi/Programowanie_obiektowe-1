using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Mammals
{
    public class Kangaroo: MammalBase, IKangaroo
    {
        #region Public Methods
        public override void Display()
        {
            Console.WriteLine($"My name is: {Name}, my age is: {Age}. I live in {Habitat} and can jump on {JumpHeight} meters");
        }
        public override void Copy(IAnimal animal)
        {
            if (animal is IKangaroo ak)
            {
                base.Copy(animal);
                Habitat = ak.Habitat;
                FamilyGroup = ak.FamilyGroup;
                JumpHeight = ak.JumpHeight;
                Lifespan = ak.Lifespan;
            }
        }
        #endregion

        #region Ctors And Properties

        public string Habitat { get; set; }
        public string FamilyGroup { get; set; }
        public double JumpHeight { get; set; }
        public int Lifespan { get; set; }

        public Kangaroo(string name, int age, string habitat, string familyGroup, double jumpHeight, int lifeSpan) : base(name, age, MammalSpecies.Kangaroo)
        {
            Habitat = habitat;
            FamilyGroup = familyGroup;
            JumpHeight = jumpHeight;
            Lifespan = lifeSpan;
        }

        #endregion
    }
}
