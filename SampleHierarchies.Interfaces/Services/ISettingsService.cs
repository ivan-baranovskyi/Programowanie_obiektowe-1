using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Interfaces.Services;

public interface ISettingsService
{
    #region Interface Members

    /// <summary>
    /// Read settings.
    /// </summary>
    /// <param name="jsonPath">Json path</param>
    /// <returns></returns>
    ISettings? Read(string jsonPath);

    /// <summary>
    /// Write settings.
    /// </summary>
    /// <param name="settings">Settings to written</param>
    /// <param name="jsonPath">Json path</param>
    void Write(ISettings settings, string jsonPath);

    /// <summary>
    /// Get screen color from json file.
    /// </summary>
    /// <param name="screenName"></param>
    /// <returns></returns>
    ConsoleColor GetScreenColorFromJson(string screenName);

    /// <summary>
    /// Set color for screen
    /// </summary>
    public void SetScreenColor(string screenName);

    #endregion // Interface Members
}
