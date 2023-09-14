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
    public sealed class FennecScreen : Screen
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

        public override string screenDefinitionJson { get; set; } = "FennecsScreenLineEntries.json";

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public FennecScreen(IDataService dataService, SettingsService settingsService)
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
                _settingsService.SetScreenColor("FennecsScreen");
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

                    FennecsScreenChoices choice = (FennecsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case FennecsScreenChoices.List:
                            ListFennecs();
                            break;

                        case FennecsScreenChoices.Create:
                            AddFennec();
                            break;

                        case FennecsScreenChoices.Delete:
                            DeleteFennec();
                            break;

                        case FennecsScreenChoices.Modify:
                            EditFennecMain();
                            break;

                        case FennecsScreenChoices.Exit:
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
        /// List all fennecs.
        /// </summary>
        private void ListFennecs()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Fennecs is not null &&
                _dataService.Animals.Mammals.Fennecs.Count > 0)
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 10);
                int i = 1;
                foreach (Fennec fennec in _dataService.Animals.Mammals.Fennecs)
                {
                    Console.Write($"Fennec number {i}, ");
                    fennec.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 11);
            }
        }

        /// <summary>
        /// Add a fennec.
        /// </summary>
        private void AddFennec()
        {
            try
            {
                Fennec fennec = AddEditFennec();
                _dataService?.Animals?.Mammals?.Fennecs?.Add(fennec);
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 12);
            }
            catch
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 13);
            }
        }

        /// <summary>
        /// Deletes a fennec.
        /// </summary>
        private void DeleteFennec()
        {
            try
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 14);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Fennec? fennec = (Fennec?)(_dataService?.Animals?.Mammals?.Fennecs
                    ?.FirstOrDefault(f => f is not null && string.Equals(f.Name, name)));
                if (fennec is not null)
                {
                    _dataService?.Animals?.Mammals?.Fennecs?.Remove(fennec);
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
        /// Edits an existing fennec after choice made.
        /// </summary>
        private void EditFennecMain()
        {
            try
            {
                ScreenDefinitionService.ShowLine(screenDefinitionJson, 18);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Fennec? fennec = (Fennec?)(_dataService?.Animals?.Mammals?.Fennecs
                    ?.FirstOrDefault(f => f is not null && string.Equals(f.Name, name)));
                if (fennec is not null)
                {
                    Fennec fennecEdited = AddEditFennec();
                    fennec.Copy(fennecEdited);
                    ScreenDefinitionService.ShowLine(screenDefinitionJson, 19);
                    fennec.Display();
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
        /// Adds/edits specific fennec.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Fennec AddEditFennec()
        {
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 22);
            string? name = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 23);
            string? ageAsString = Console.ReadLine();

            ScreenDefinitionService.ShowLine(screenDefinitionJson, 24);
            string? earSizeAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 25);
            string? coatPattern = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 26);
            string? tailLengthAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 27);
            string? dietaryHabits = Console.ReadLine();
            ScreenDefinitionService.ShowLine(screenDefinitionJson, 28);
            string? runningSpeedAsString = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (earSizeAsString is null)
            {
                throw new ArgumentNullException(nameof(earSizeAsString));
            }
            if (coatPattern is null)
            {
                throw new ArgumentNullException(nameof(coatPattern));
            }
            if (tailLengthAsString is null)
            {
                throw new ArgumentNullException(nameof(tailLengthAsString));
            }
            if (dietaryHabits is null)
            {
                throw new ArgumentNullException(nameof(dietaryHabits));
            }
            if (runningSpeedAsString is null)
            {
                throw new ArgumentNullException(nameof(runningSpeedAsString));
            }

            int age = Int32.Parse(ageAsString);
            double earSize = Double.Parse(earSizeAsString);
            double tailLength = Double.Parse(tailLengthAsString);
            double runningSpeed = Double.Parse(runningSpeedAsString);

            Fennec fennec = new Fennec(name, age, earSize, coatPattern, tailLength, dietaryHabits, runningSpeed);

            return fennec;
        }

        #endregion // Private Methods
    }

}
