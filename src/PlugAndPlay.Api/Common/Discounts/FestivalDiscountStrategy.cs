namespace PlugAndPlay.Api.Common.Discounts;

public class FestivalDiscountStrategy : IDiscountStrategy
{
    public string DiscountType => "Festival";

    public decimal Calculate(decimal amount)
    {
        return amount * 0.10m;
    }
}
