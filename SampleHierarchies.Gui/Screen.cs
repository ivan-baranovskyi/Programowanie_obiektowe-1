using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Abstract base class for a screen.
/// </summary>
public abstract class Screen
{
    public virtual string screenDefinitionJson { get; set; }

    #region Public Methods

    /// <summary>
    /// Show the screen.
    /// </summary>
    public virtual void Show()
    {
        Console.WriteLine("Showing screen");
    }

    #endregion // Public Methods
}
