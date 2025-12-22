namespace PlugAndPlay.Api.Managers;

using PlugAndPlay.Api.Models;
using PlugAndPlay.Api.Providers;

public class EmployeeManager : IEmployeeManager
{
    private readonly IEmployeeProvider _employeeProvider;
    public EmployeeManager(IEmployeeProvider employeeProvider)
    {
        _employeeProvider = employeeProvider;
    }
    public async Task<List<Employee>> GetEmployeesAsync()
    {
        // Business rules can be added here later
        return await _employeeProvider.GetEmployeesAsync();
    }
}