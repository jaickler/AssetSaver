using AssetSaverCore.Inventory.Models;
using AssetSaverCore.Inventory.Services;

namespace AssetSaverTests.Inventory;

[TestClass]
public class StraightLineValueCalculatorTests
{
    private readonly int _maxYears = 15;
    private readonly int _priceAtPurchase = 5000;
    private readonly DateTime _purchaseDate = DateTime.Today;
    private readonly int _salvageValue = 800;
    private readonly IValueCalculator _valueCalculator = new StraightLineValueCalculator();
    private Item? _item;
    private ValueCalculatorOptions? _options;

    [TestInitialize]
    public void Setup()
    {
        _item = new Item("Couch",
            _priceAtPurchase,
            datePurchased: _purchaseDate);

        _options = new ValueCalculatorOptions
        {
            SalvageValue = _salvageValue,
            UsefulLife = TimeSpan.FromDays(365 * _maxYears)
        };
    }

    [TestMethod]
    public void DepreciationReachesFullValue()
    {
        if (_item is null)
            throw new NullReferenceException("The item was null. Should be assigned in Setup method.");
        var finalDate = _item.PurchaseDate.AddYears(_maxYears);

        var finalPrice = _valueCalculator.GetPriceForDate(finalDate, _item, _options);

        Assert.AreEqual(800, finalPrice, "The depreciation is not being calculated properly");
    }

    [TestMethod]
    public void DepreciationForOneYearIsCorrect()
    {
        if (_item is null)
            throw new NullReferenceException("The item was null. Should be assigned in Setup method.");
        var depreciationPerYear = (_item.PriceAtPurchase - _salvageValue) / _maxYears;
        var finalDate = _item.PurchaseDate.AddYears(1);

        var finalPrice = _valueCalculator.GetPriceForDate(finalDate, _item, _options);

        Assert.AreEqual(_item.PriceAtPurchase - depreciationPerYear, finalPrice,
            "The depreciation is not being calculated properly");
    }
}