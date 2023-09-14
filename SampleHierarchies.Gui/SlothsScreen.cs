using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Gui
{
    public sealed class SlothsScreen : Screen
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

        public override string screenDefinitionJson { get; set; } = "SlothsScreenLineEntries.json";

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public SlothsScreen(IDataService dataService, SettingsService settingsService)
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
                _settingsService.SetScreenColor("SlothsScreen");
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

                    SlothsScreenChoices choice = (SlothsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case SlothsScreenChoices.List:
                            ListSloths();
                            break;

                        case SlothsScreenChoices.Create:
                            AddSloth();
                            break;

                        case SlothsScreenChoices.Delete:
                            DeleteSloth();
                            break;

                        case SlothsScreenChoices.Modify:
                            EditSlothMain();
                            break;

                        case SlothsScreenChoices.Exit:
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
        /// List all sloths.
        /// </summary>
        private void ListSloths()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Sloths is not null &&
                _dataService.Animals.Mammals.Sloths.Count > 0)
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 10);
                int i = 1;
                foreach (Sloth sloth in _dataService.Animals.Mammals.Sloths)
                {
                    Console.Write($"Sloth number {i}, ");
                    sloth.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 11);
            }
        }

        /// <summary>
        /// Add a sloth.
        /// </summary>
        private void AddSloth()
        {
            try
            {
                Sloth sloth = AddEditSloth();
                _dataService?.Animals?.Mammals?.Sloths?.Add(sloth);
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 12);
            }
            catch
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 13);
            }
        }

        /// <summary>
        /// Deletes a sloth.
        /// </summary>
        private void DeleteSloth()
        {
            try
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 14);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Sloth? sloth = (Sloth?)(_dataService?.Animals?.Mammals?.Sloths
                    ?.FirstOrDefault(s => s is not null && string.Equals(s.Name, name)));
                if (sloth is not null)
                {
                    _dataService?.Animals?.Mammals?.Sloths?.Remove(sloth);
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
        /// Edits an existing sloth after choice made.
        /// </summary>
        private void EditSlothMain()
        {
            try
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 18);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Sloth? sloth = (Sloth?)(_dataService?.Animals?.Mammals?.Sloths
                    ?.FirstOrDefault(s => s is not null && string.Equals(s.Name, name)));
                if (sloth is not null)
                {
                    Sloth slothEdited = AddEditSloth();
                    sloth.Copy(slothEdited);
                    ScreenDefinitionService.ShowLine(screenDefinitionJson, 19);
                    sloth.Display();
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
        /// Adds/edits specific sloth.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Sloth AddEditSloth()
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 22);
            string? name = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 23);
            string? ageAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 24);
            string? furColor = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 25);
            string? diet = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 26);
            string? climbingSpeedAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 27);
            string? dailyActivityHoursAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 28);
            string? sleepingTimeAsString = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (furColor is null)
            {
                throw new ArgumentNullException(nameof(furColor));
            }
            if (diet is null)
            {
                throw new ArgumentNullException(nameof(diet));
            }
            if (climbingSpeedAsString is null)
            {
                throw new ArgumentNullException(nameof(climbingSpeedAsString));
            }
            if (dailyActivityHoursAsString is null)
            {
                throw new ArgumentNullException(nameof(dailyActivityHoursAsString));
            }
            if (sleepingTimeAsString is null)
            {
                throw new ArgumentNullException(nameof(sleepingTimeAsString));
            }

            int age = Int32.Parse(ageAsString);
            double climbingSpeed = Double.Parse(climbingSpeedAsString);
            int dailyActivityHours = Int32.Parse(dailyActivityHoursAsString);
            int sleepingTime = Int32.Parse(sleepingTimeAsString);

            Sloth sloth = new Sloth(name, age, furColor, diet, climbingSpeed, dailyActivityHours, sleepingTime);

            return sloth;
        }

        #endregion // Private Methods
    }
}
