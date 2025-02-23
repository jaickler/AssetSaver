namespace AssetSaverCore.Inventory.Models;

/// <summary>
///     The Model to represent the most basic item.
/// </summary>
/// <param name="name">The name of this item.</param>
public class Item(
    string name,
    int priceAtPurchase,
    Location? location = null,
    List<Uri>? images = null,
    Dictionary<Guid, string>? categories = null,
    DateTime? datePurchased = null,
    Guid? id = null)
{
    /// <summary>
    ///     The unique ID for this item.
    /// </summary>
    public Guid Id { get; set; } = id ?? Guid.NewGuid();

    /// <summary>
    ///     The name of the item.
    /// </summary>
    public string Name { get; set; } = name;

    public List<Uri> Images { get; set; } = images ?? new List<Uri>();

    public Location? Location { get; set; } = location;

    /// <summary>
    ///     The categories that apply to this item.
    /// </summary>
    public Dictionary<Guid, string> Categories { get; set; } = categories ?? new Dictionary<Guid, string>();

    /// <summary>
    ///     The date that the item was purchased.
    /// </summary>
    public DateTime PurchaseDate { get; init; } = datePurchased ?? DateTime.Now;

    /// <summary>
    ///     The price of this item at time of purchase.
    /// </summary>
    public int PriceAtPurchase { get; init; } = priceAtPurchase;

    /// <summary>
    ///     The price of this item currently.
    /// </summary>
    public int Price
    {
        get
        {
            var yearsSinceBought = PurchaseDate.Year - DateTime.Now.Year;
            return PriceAtPurchase * yearsSinceBought / 100;
        }
    }
}