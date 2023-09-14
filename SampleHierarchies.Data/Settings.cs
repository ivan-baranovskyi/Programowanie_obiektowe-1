using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    public class Settings : ISettings
    {
        public string? Version { get; set; }
        public ConsoleColor screenColor { get; set; }
    }
}
