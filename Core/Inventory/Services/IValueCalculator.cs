using AssetSaverCore.Inventory.Models;

namespace AssetSaverCore.Inventory.Services;

/// <summary>
///     The standard interface for Value Calculators that generate prices based on time since purchase of an item.
/// </summary>
public interface IValueCalculator
{
    /// <summary>
    ///     Gets the calculated price of an item for the given <paramref name="targetDate" />.
    /// </summary>
    /// <param name="targetDate">The date to use for calculating the price.</param>
    /// <param name="purchasePrice">The price of the item at purchase.</param>
    /// <param name="purchaseDate">The date that the item was purchased.</param>
    /// <param name="options">The <see cref="ValueCalculatorOptions" /> to use for this calculation if needed.</param>
    /// <returns>The price of the item at <paramref name="targetDate" />.</returns>
    int GetPriceForDate(DateTime targetDate, int purchasePrice, DateTime purchaseDate,
        ValueCalculatorOptions? options = null);

    /// <summary>
    ///     Gets the calculated price of an <paramref name="item" /> for the given <paramref name="targetDate" />.
    /// </summary>
    /// <param name="targetDate">The date to use for calculating the price.</param>
    /// <param name="item"></param>
    /// <param name="options">The <see cref="ValueCalculatorOptions" /> to use for this calculation if needed.</param>
    /// <returns>The price of the <paramref name="item" /> at <paramref name="targetDate" />.</returns>
    int GetPriceForDate(DateTime targetDate, Item item, ValueCalculatorOptions? options = null);

    /// <summary>
    ///     Gets the calculated price of the item for the current date.
    /// </summary>
    /// <param name="purchasePrice">The price of the item at purchase.</param>
    /// <param name="purchaseDate">The date that the item was purchased.</param>
    /// <param name="options">The <see cref="ValueCalculatorOptions" /> to use for this calculation if needed.</param>
    /// <returns>The current price of the item.</returns>
    int GetCurrentPrice(int purchasePrice, DateTime purchaseDate, ValueCalculatorOptions? options = null);

    /// <summary>
    ///     Gets the calculated price of the <paramref name="item" /> at purchase.
    /// </summary>
    /// <param name="item">The item to calculate the price for.</param>
    /// <param name="options">The <see cref="ValueCalculatorOptions" /> to use for this calculation if needed.</param>
    /// <returns>The current price of the <paramref name="item" />.</returns>
    int GetCurrentPrice(Item item, ValueCalculatorOptions? options = null);
}