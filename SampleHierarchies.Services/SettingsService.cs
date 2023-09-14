using Newtonsoft.Json.Linq;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Services;

/// <summary>
/// Settings service.
/// </summary>
public class SettingsService : ISettingsService
{
    private string FilePath { get; set; } = "screenColorSettings.json";

    #region ISettingsService Implementation
    /// <inheritdoc/>
    public ISettings? Read(string jsonPath)
    {
        ISettings? result = null;

        return result;
    }

    /// <inheritdoc/>
    public void Write(ISettings settings, string jsonPath)
    {
        
    }

    /// <summary>
    /// Edit settings (colors) of screen 
    /// </summary>
    public void EditSettings()
    {
        try
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                dynamic jsonObject = JObject.Parse(json);

                Console.Write("Enter a name of screen, you want to edit: ");
                string? screenName = Console.ReadLine();

                if (jsonObject[screenName] != null)
                {
                    Console.WriteLine($"Current value of '{screenName}': {jsonObject[screenName]}");

                    Console.WriteLine("Here are all the color options you can enter:");

                    ConsoleColor[] colorValues = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
                    int half = colorValues.Length / 2;

                    for (int i = 0; i < half; i++)
                    {
                        Console.WriteLine($"{colorValues[i],-12}{colorValues[i + half]}");
                    }
                    Console.Write($"Enter a new color for {screenName}: ");
                    string? newValue = Console.ReadLine();

                    if( newValue != null )
                        jsonObject[screenName] = JToken.FromObject(newValue);


                    File.WriteAllText(FilePath, jsonObject.ToString());

                    Console.WriteLine($"Value of property '{screenName}' updated successfully.");
                }
                else
                {
                    Console.WriteLine($"Property '{screenName}' in file.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while editing the JSON file: {ex.Message}");
        }
    }

    /// <summary>
    /// Get screen color from screenColorSettings.json
    /// </summary>
    /// <param name="screenName"></param>
    /// <returns></returns>
    public ConsoleColor GetScreenColorFromJson(string screenName)
    {
        try
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                dynamic jsonObject = JObject.Parse(json);

                if (jsonObject[screenName] != null)
                {
                    JToken propertyValue = jsonObject[screenName];
                    if (propertyValue.Type != JTokenType.Null)
                    {
                        if (Enum.TryParse<ConsoleColor>(propertyValue.ToString(), out ConsoleColor color))
                        {
                            return color;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the JSON file: {ex.Message}");
        }

        return ConsoleColor.White; // Default value
    }

    /// <summary>
    /// Set color of screen
    /// </summary>
    /// <param name="screenName"></param>
    public void SetScreenColor(string screenName)
    {
        Console.ForegroundColor = GetScreenColorFromJson(screenName);
    }

    #endregion // ISettings Implementation
}