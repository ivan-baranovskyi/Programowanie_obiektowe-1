﻿namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Settings interface.
/// </summary>
public interface ISettings
{
    #region Interface Members

    /// <summary>
    /// Version of settings.
    /// </summary>
    string? Version { get; set; }

    ConsoleColor screenColor { get; set; }

    #endregion // Interface Members
}

