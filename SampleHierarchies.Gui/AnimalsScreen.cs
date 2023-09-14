using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Animals main screen.
/// </summary>
public sealed class AnimalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private MammalsScreen _mammalsScreen;

    /// <summary>
    /// Settings service.
    /// </summary>
    private SettingsService _settingsService;

    public override string screenDefinitionJson { get; set; } = "AnimalsScreenLineEntries.json";

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public AnimalsScreen(
        IDataService dataService,
        MammalsScreen mammalsScreen,
        SettingsService settingsService)
    {
        _dataService = dataService;
        _mammalsScreen = mammalsScreen;
        _settingsService = settingsService;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.SetScreenColor("AnimalsScreen");
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 0);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 1);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 2);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 3);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 4);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 5);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 6);

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                AnimalsScreenChoices choice = (AnimalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case AnimalsScreenChoices.Mammals:
                        Console.Clear();
                        _mammalsScreen.Show();
                        break;

                    case AnimalsScreenChoices.Read:
                        ReadFromFile();
                        break;

                    case AnimalsScreenChoices.Save:
                        SaveToFile();
                        break;

                    case AnimalsScreenChoices.Exit:
                        ScreenDefinitionService.ShowLine(screenDefinitionJson, 7);
                        Thread.Sleep(1000);
                        Console.Clear();        
                        return;
                }
            }
            catch
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 8);
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// Save to file.
    /// </summary>
    private void SaveToFile()
    {
        try
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 9);
            var fileName = Console.ReadLine();
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            _dataService.Write(fileName);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 10);
        }
        catch
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 11);
        }
    }

    /// <summary>
    /// Read data from file.
    /// </summary>
    private void ReadFromFile()
    {
        try
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 12);
            var fileName = Console.ReadLine();
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            _dataService.Write(fileName);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 13);
        }
        catch
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 14);
        }
    }

    #endregion // Private Methods
}
