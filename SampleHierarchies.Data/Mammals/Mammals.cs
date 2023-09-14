using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Mammals collection.
/// </summary>
public class Mammals : IMammals
{
    #region IMammals Implementation

    /// <inheritdoc/>
    public List<IDog> Dogs { get; set; }

    public List<IKangaroo> Kangaroos { get; set; }
    
    public List<ISloth> Sloths { get; set; }

    public List<IFennec> Fennecs { get; set; }

    #endregion // IMammals Implementation

    #region Ctors

    /// <summary>
    /// Default ctor.
    /// </summary>
    public Mammals()
    {
        Dogs = new List<IDog>();
        Kangaroos = new List<IKangaroo>();
        Sloths = new List<ISloth>();
        Fennecs = new List<IFennec>();
    }

    #endregion // Ctors
}
