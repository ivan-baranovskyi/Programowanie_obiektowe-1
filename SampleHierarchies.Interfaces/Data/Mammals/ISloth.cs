using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    public interface ISloth : IMammal
    {
        int SleepingTime { get; set; }
        string FurColor { get; set; }
        string Diet { get; set; }
        double ClimbingSpeed { get; set; }
        int DailyActivityHours { get; set; }
    }
}
