namespace AssetSaverCore.Inventory.Models;

/// <summary>
///     The model to represent the location of one or more <see cref="Item" />.
/// </summary>
/// <param name="name">The name of the location.</param>
/// <param name="id">The unique id of the location.</param>
public class Location(string? name, Guid? id = null)
{
    /// <summary>
    ///     The unique id of this location.
    /// </summary>
    public Guid Id { get; set; } = id ?? Guid.NewGuid();

    /// <summary>
    ///     The name of this location.
    /// </summary>
    public string Name { get; set; } = name ?? string.Empty;
}