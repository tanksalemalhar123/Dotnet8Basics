using Microsoft.AspNetCore.Mvc;
using PlugAndPlay.Api.Managers;

namespace PlugAndPlay.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly OrderManager _orderManager;

    public OrderController(OrderManager orderManager)
    {
        _orderManager = orderManager;
    }

    [HttpGet("discount")]
    public IActionResult GetDiscount(
        string discountType,
        decimal amount)
    {
        var discountedAmount =
            _orderManager.ApplyDiscount(discountType, amount);

        return Ok(new
        {
            DiscountType = discountType,
            OriginalAmount = amount,
            DiscountedAmount = discountedAmount
        });
    }
}
