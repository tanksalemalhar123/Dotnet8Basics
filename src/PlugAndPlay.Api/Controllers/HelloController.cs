using Microsoft.AspNetCore.Mvc;
using PlugAndPlay.Api.Models;
using System.Threading.Tasks;
using PlugAndPlay.Api.Managers;

namespace PlugAndPlay.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class HelloController : BaseController
{
    private readonly HelloManager _helloManager;

    public HelloController(HelloManager helloManager)
    {
        _helloManager = helloManager;
    }

    [HttpGet]
    [Produces("application/json")]
    public async Task<IActionResult> GetMessage()
    {
        var result = await _helloManager.GetFewRecords();
        return ConvertManagerResultToBuildResponse(result);
    }

    [HttpGet("TwoRows")]
    [Produces("application/json")]
    public async Task<IActionResult> GetTwoRows()
    {
        var result = await _helloManager.GetTwoRows();
        return ConvertManagerResultToBuildResponse(result);
    }

    [HttpGet("GetArray")]
    [Produces("application/json")]
    public async Task<IActionResult> GetTwoArrays()
    {
        var result = await _helloManager.GetTwoArrays();
        return ConvertManagerResultToBuildResponse(result);
    }

    [HttpGet("db-test")]
    public async Task<IActionResult> TestDb()
    {
        var result = await _helloManager.TestDb();
        return ConvertManagerResultToBuildResponse(result);
    }

    [HttpGet("employees")]
    public async Task<IActionResult> GetEmployees()
    {
        var result = await _helloManager.GetEmployees();
        return ConvertManagerResultToBuildResponse(result);
    }

    [HttpGet("orders")]
    public async Task<IActionResult> GetOrders()
    {
        var result = await _helloManager.GetOrders();
        return ConvertManagerResultToBuildResponse(result);
    }


    [HttpGet("orderswithusers")]
    public async Task<IActionResult> GetOrdersWithUsers()
    {
        var result = await _helloManager.GetOrdersWithUsers();
        return ConvertManagerResultToBuildResponse(result);
    }

}