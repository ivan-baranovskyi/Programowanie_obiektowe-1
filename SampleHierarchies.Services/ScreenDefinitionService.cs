using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Services
{
    public static class ScreenDefinitionService
    {
        public static ScreenDefinition Load(string jsonFileName)
        {
            try
            {
                string content = File.ReadAllText(jsonFileName);
                ScreenDefinition? screenDefinition = JsonConvert.DeserializeObject<ScreenDefinition>(content);
                if (screenDefinition != null)
                    return screenDefinition;
                else
                    throw new Exception("Bad read from file");
            }
            catch
            {
                throw new Exception("File is not found");
            }
        }

        public static void ShowLine(string jsonFileName, int numberLineEntry)
        {
            ScreenDefinition? screenDefinition = Load(jsonFileName);
            if (screenDefinition.LineEntries != null)
            {
                Console.ForegroundColor = screenDefinition.LineEntries[numberLineEntry].ForegroundColor;
                Console.BackgroundColor = screenDefinition.LineEntries[numberLineEntry].BackgroundColor;
                Console.WriteLine(screenDefinition.LineEntries[numberLineEntry].Text);
                Console.ResetColor(); 
            }
            else
            {
                throw new Exception("The line was read incorrectly");
            }
        }
    }
}
