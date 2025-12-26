using PlugAndPlay.Api.Common.Discounts;

namespace PlugAndPlay.Api.Managers;

public class OrderManager
{
    private readonly IEnumerable<IDiscountStrategy> _discountStrategies;

    public OrderManager(IEnumerable<IDiscountStrategy> discountStrategies)
    {
        _discountStrategies = discountStrategies;
    }

    public decimal ApplyDiscount(string discountType, decimal amount)
    {
        var strategy = _discountStrategies
            .FirstOrDefault(x => x.DiscountType == discountType);

        if (strategy == null)
            throw new InvalidOperationException($"Discount '{discountType}' not supported");

        return strategy.Calculate(amount);
    }
}
