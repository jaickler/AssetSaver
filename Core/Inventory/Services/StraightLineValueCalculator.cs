using AssetSaverCore.Inventory.Models;

namespace AssetSaverCore.Inventory.Services;

public class StraightLineValueCalculator : IValueCalculator
{
    public int GetPriceForDate(DateTime targetDate, int purchasePrice, DateTime purchaseDate,
        ValueCalculatorOptions? options = null)
    {
        if (options is null)
            throw new ArgumentNullException(nameof(options),
                "options cannot be null for straight line value calculation.");
        var totalDepreciation = purchasePrice - options.SalvageValue;
        var usefulYears = options.UsefulLife.TotalDays / 365;
        var depreciationPerYear = totalDepreciation / usefulYears;

        var yearsSincePurchase = targetDate.Year - purchaseDate.Year;

        return purchasePrice - (int)Math.Round(depreciationPerYear * yearsSincePurchase);
    }

    public int GetPriceForDate(DateTime targetDate, Item item, ValueCalculatorOptions? options = null)
    {
        if (options is null)
            throw new ArgumentNullException(nameof(options),
                "options cannot be null for straight line value calculation.");
        return GetPriceForDate(targetDate, item.PriceAtPurchase, item.PurchaseDate, options);
    }

    public int GetCurrentPrice(int purchasePrice, DateTime purchaseDate, ValueCalculatorOptions? options = null)
    {
        if (options is null)
            throw new ArgumentNullException(nameof(options),
                "options cannot be null for straight line value calculation.");
        return GetPriceForDate(DateTime.Today, purchasePrice, purchaseDate, options);
    }

    public int GetCurrentPrice(Item item, ValueCalculatorOptions? options = null)
    {
        if (options is null)
            throw new ArgumentNullException(nameof(options),
                "options cannot be null for straight line value calculation.");
        return GetCurrentPrice(item.PriceAtPurchase, item.PurchaseDate, options);
    }
}