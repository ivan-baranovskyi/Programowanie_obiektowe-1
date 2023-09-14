using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    public interface IFennec: IMammal
    {
        double EarSize { get; set;}
        string CoatPattern { get; set; }
        double TailLength { get; set; }
        string DietaryHabits { get; set; }
        double RunningSpeed { get; set; }
    }
}
