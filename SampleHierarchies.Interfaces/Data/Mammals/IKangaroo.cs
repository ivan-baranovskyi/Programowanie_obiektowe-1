using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    public interface IKangaroo : IMammal
    {
        string Habitat { get; set; }
        string FamilyGroup { get; set; }
        double JumpHeight { get; set; }
        int Lifespan { get; set; }
    }
}
