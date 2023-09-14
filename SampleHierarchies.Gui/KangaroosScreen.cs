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
    public sealed class KangaroosScreen : Screen
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

        public override string screenDefinitionJson { get; set; } = "KangaroosScreenLineEntries.json";

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public KangaroosScreen(IDataService dataService, SettingsService settingsService)
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
                _settingsService.SetScreenColor("KangaroosScreen");
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

                    KangaroosScreenChoices choice = (KangaroosScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case KangaroosScreenChoices.List:
                            ListKangaroos();
                            break;

                        case KangaroosScreenChoices.Create:
                            AddKangaroo();
                            break;

                        case KangaroosScreenChoices.Delete:
                            DeleteKangaroo();
                            break;

                        case KangaroosScreenChoices.Modify:
                            EditKangarooMain();
                            break;

                        case KangaroosScreenChoices.Exit:
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
        /// List all kangaroos.
        /// </summary>
        private void ListKangaroos()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Kangaroos is not null &&
                _dataService.Animals.Mammals.Kangaroos.Count > 0)
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 10);
                int i = 1;
                foreach (Kangaroo kangaroo in _dataService.Animals.Mammals.Kangaroos)
                {
                    Console.Write($"Kangaroo number {i}, ");
                    kangaroo.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 11);
            }
        }

        /// <summary>
        /// Add a kangaroo.
        /// </summary>
        private void AddKangaroo()
        {
            try
            {
                Kangaroo kangaroo = AddEditKangaroo();
                _dataService?.Animals?.Mammals?.Kangaroos?.Add(kangaroo);
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 12);
            }
            catch
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 13);
            }
        }

        /// <summary>
        /// Deletes a kangaroo.
        /// </summary>
        private void DeleteKangaroo()
        {
            try
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 14);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Kangaroo? kangaroo = (Kangaroo?)(_dataService?.Animals?.Mammals?.Kangaroos
                    ?.FirstOrDefault(k => k is not null && string.Equals(k.Name, name)));
                if (kangaroo is not null)
                {
                    _dataService?.Animals?.Mammals?.Kangaroos?.Remove(kangaroo);
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
        /// Edits an existing kangaroo after choice made.
        /// </summary>
        private void EditKangarooMain()
        {
            try
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 18);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Kangaroo? kangaroo = (Kangaroo?)(_dataService?.Animals?.Mammals?.Kangaroos
                    ?.FirstOrDefault(k => k is not null && string.Equals(k.Name, name)));
                if (kangaroo is not null)
                {
                    Kangaroo kangarooEdited = AddEditKangaroo();
                    kangaroo.Copy(kangarooEdited);
                    ScreenDefinitionService.ShowLine(screenDefinitionJson, 19);
                    kangaroo.Display();
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
        /// Adds/edits specific kangaroo.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Kangaroo AddEditKangaroo()
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 22);
            string? name = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 23);
            string? ageAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 24);
            string? habitat = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 25);
            string? familyGroup = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 26);
            string? jumpHeightAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 27);
            string? lifespanAsString = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (habitat is null)
            {
                throw new ArgumentNullException(nameof(habitat));
            }
            if (familyGroup is null)
            {
                throw new ArgumentNullException(nameof(familyGroup));
            }
            if (jumpHeightAsString is null)
            {
                throw new ArgumentNullException(nameof(jumpHeightAsString));
            }
            if (lifespanAsString is null)
            {
                throw new ArgumentNullException(nameof(lifespanAsString));
            }

            int age = Int32.Parse(ageAsString);
            double jumpHeight = Double.Parse(jumpHeightAsString);
            int lifespan = Int32.Parse(lifespanAsString);

            Kangaroo kangaroo = new Kangaroo(name, age, habitat, familyGroup, jumpHeight, lifespan);

            return kangaroo;
        }
        #endregion // Private Methods
    }
}
