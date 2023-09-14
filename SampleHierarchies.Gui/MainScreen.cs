using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private AnimalsScreen _animalsScreen;

    private SettingsService _settingsService;

    public override string screenDefinitionJson { get; set; } = "MainScreenLineEntries.json";

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public MainScreen(
        IDataService dataService,
        AnimalsScreen animalsScreen,
        SettingsService settingsService)
    {
        _dataService = dataService;
        _animalsScreen = animalsScreen;
        _settingsService = settingsService;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.SetScreenColor("MainScreen");
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 0);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 1);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 2);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 3);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 4);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 5);

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MainScreenChoices.Animals:
                        Console.Clear();
                        _animalsScreen.Show();
                        break;

                    case MainScreenChoices.Settings:
                        _settingsService.EditSettings();
                        break;

                    case MainScreenChoices.Exit:
                        ScreenDefinitionService.ShowLine(screenDefinitionJson, 6);
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }

    #endregion // Public Methods
}