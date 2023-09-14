using System.ComponentModel;
/// <summary>
/// Dummy enum.
/// </summary>
public enum MammalSpecies
{
    [Description("Simple description of a none")]
    None = 0,
    [Description("Simple description of a dog")]
    Dog = 1,
    [Description("Simple description of a kangaroo")]
    Kangaroo = 2,
    [Description("Simple description of a sloth")]
    Sloth = 3,
    [Description("Simple description of a fennec")]
    Fennec = 4,
}
