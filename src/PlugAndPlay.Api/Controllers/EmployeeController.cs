namespace PlugAndPlay.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using PlugAndPlay.Api.Managers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeManager _employeeManager;

    public EmployeeController(IEmployeeManager employeeManager)
    {
        _employeeManager = employeeManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var employees = await _employeeManager.GetEmployeesAsync();
        return Ok(employees);
    }
}
