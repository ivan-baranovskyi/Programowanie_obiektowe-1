using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class DogsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Settings service.
    /// </summary>
    private SettingsService _settingsService;

    public override string screenDefinitionJson { get; set; } = "DogsScreenLineEntries.json";

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public DogsScreen(IDataService dataService, SettingsService settingsService)
    {
        _dataService = dataService;
        _settingsService = settingsService;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        ScreenDefinitionService.ShowLine(screenDefinitionJson, 0);
        while (true)
        {
            _settingsService.SetScreenColor("DogsScreen");
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

                DogsScreenChoices choice = (DogsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case DogsScreenChoices.List:
                        ListDogs();
                        break;

                    case DogsScreenChoices.Create:
                        AddDog(); break;

                    case DogsScreenChoices.Delete: 
                        DeleteDog();
                        break;

                    case DogsScreenChoices.Modify:
                        EditDogMain();
                        break;

                    case DogsScreenChoices.Exit:
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

    #region Private Methods

    /// <summary>
    /// List all dogs.
    /// </summary>
    private void ListDogs()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Dogs is not null &&
            _dataService.Animals.Mammals.Dogs.Count > 0)
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 10);
            int i = 1;
            foreach (Dog dog in _dataService.Animals.Mammals.Dogs)
            {
                Console.Write($"Dog number {i}, ");
                dog.Display();
                i++;
            }
        }
        else
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 11);
        }
    }

    /// <summary>
    /// Add a dog.
    /// </summary>
    private void AddDog()
    {
        try
        {
            Dog dog = AddEditDog();
            _dataService?.Animals?.Mammals?.Dogs?.Add(dog);
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 12);
        }
        catch
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 13);
        }
    }

    /// <summary>
    /// Deletes a dog.
    /// </summary>
    private void DeleteDog()
    {
        try
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 14);
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Dog? dog = (Dog?)(_dataService?.Animals?.Mammals?.Dogs
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (dog is not null)
            {
                _dataService?.Animals?.Mammals?.Dogs?.Remove(dog);
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 15);
            }
            else
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 16);
            }
        }
        catch
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 17);
        }
    }

    /// <summary>
    /// Edits an existing dog after choice made.
    /// </summary>
    private void EditDogMain()
    {
        try
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 18);
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Dog? dog = (Dog?)(_dataService?.Animals?.Mammals?.Dogs
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (dog is not null)
            {
                Dog dogEdited = AddEditDog();
                dog.Copy(dogEdited);
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 19);
                dog.Display();
            }
            else
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 20);
            }
        }
        catch
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 21);
        }
    }

    /// <summary>
    /// Adds/edit specific dog.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Dog AddEditDog()
    {
        ScreenDefinitionService.ShowLine(screenDefinitionJson, 22);
        string? name = Console.ReadLine();
        ScreenDefinitionService.ShowLine(screenDefinitionJson, 23);
        string? ageAsString = Console.ReadLine();
        ScreenDefinitionService.ShowLine(screenDefinitionJson, 24);
        string? breed = Console.ReadLine();

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (breed is null)
        {
            throw new ArgumentNullException(nameof(breed));
        }
        int age = Int32.Parse(ageAsString);
        Dog dog = new Dog(name, age, breed);

        return dog;
    }

    #endregion // Private Methods
}
