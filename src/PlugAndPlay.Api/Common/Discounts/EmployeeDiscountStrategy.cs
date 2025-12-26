namespace PlugAndPlay.Api.Common.Discounts;

public class EmployeeDiscountStrategy : IDiscountStrategy
{
    public string DiscountType => "Employee";

    public decimal Calculate(decimal amount)
    {
        return amount * 0.20m;
    }
}
