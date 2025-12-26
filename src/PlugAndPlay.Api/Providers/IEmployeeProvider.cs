namespace PlugAndPlay.Api.Providers;

using PlugAndPlay.Api.Models;

public interface IEmployeeProvider
{
    Task<List<Employee>> GetEmployeesAsync();
}
//ISP Principle