namespace PlugAndPlay.Api.Models;

public class Product
{
    public int Id { get; set; }

    public required string Name { get; set; }

    // numeric(10,2) → decimal
    public decimal Price { get; set; }

    public int Stock { get; set; }

    // Navigation: one product → many orders
    public List<Order> Orders { get; set; } = new();
}
