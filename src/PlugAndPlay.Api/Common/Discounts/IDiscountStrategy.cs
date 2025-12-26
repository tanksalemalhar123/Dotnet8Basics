namespace PlugAndPlay.Api.Common.Discounts;

public interface IDiscountStrategy
{
    string DiscountType { get; }
    decimal Calculate(decimal amount);
}
