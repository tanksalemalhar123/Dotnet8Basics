namespace PlugAndPlay.Api.Models;

public class Order
{
    public int Id { get; set; }

    // FK → users.id
    public int UserId { get; set; }
    public required User User { get; set; }

// FK → products.id
public int ProductId { get; set; }
public required Product Product { get; set; }

    public int Quantity { get; set; }

public DateTime OrderDate { get; set; }
}
