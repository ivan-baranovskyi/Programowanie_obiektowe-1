using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Animals screen.
    /// </summary>
    private DogsScreen _dogsScreen;

    /// <summary>
    /// Kangaroos screen.
    /// </summary>
    private KangaroosScreen _kangaroosScreen;

    /// <summary>
    /// Kangaroos screen.
    /// </summary>
    private SlothsScreen _slothsScreen;

    /// <summary>
    /// Fennecs screen
    /// </summary>
    private FennecScreen _fennecsScreen;

    /// <summary>
    /// Settings service.
    /// </summary>
    private SettingsService _settingsService;

    public override string screenDefinitionJson { get; set; } = "MammalsScreenLineEntries.json";

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    public MammalsScreen(DogsScreen dogsScreen,KangaroosScreen kangaroosScreen, SettingsService settingsService, SlothsScreen slothsScreen, FennecScreen fennecsScreen)
    {
        _dogsScreen = dogsScreen;
        _kangaroosScreen = kangaroosScreen;
        _settingsService = settingsService;
        _slothsScreen = slothsScreen;
        _fennecsScreen = fennecsScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.SetScreenColor("MammalsScreen");
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 0);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 1);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 2);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 3);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 4);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 5);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 6);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 7);

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        Console.Clear();
                        _dogsScreen.Show();
                        break;
                    case MammalsScreenChoices.Kangaroos:
                        Console.Clear();
                        _kangaroosScreen.Show(); 
                        break;
                    case MammalsScreenChoices.Sloths:
                        Console.Clear();
                        _slothsScreen.Show();
                        break;
                    case MammalsScreenChoices.Fennecs:
                        Console.Clear();
                        _fennecsScreen.Show();
                        break;

                    case MammalsScreenChoices.Exit: 
                        ScreenDefinitionService.ShowLine(screenDefinitionJson, 8);
                        Thread.Sleep(1000);
                        Console.Clear();
                        return;
                }
            }
            catch
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 9);
            }
        }
    }

    #endregion // Public Methods
}
