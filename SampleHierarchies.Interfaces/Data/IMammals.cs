using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Mammals collection.
/// </summary>
public interface IMammals
{
    #region Interface Members

    /// <summary>
    /// Dogs collection.
    /// </summary>
    List<IDog> Dogs { get; set; }
    List<IKangaroo> Kangaroos { get; set; }
    List<ISloth> Sloths { get; set; }
    List<IFennec> Fennecs { get; set; }
    #endregion // Interface Members
}
