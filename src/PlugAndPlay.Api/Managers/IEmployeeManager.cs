namespace PlugAndPlay.Api.Managers;

using PlugAndPlay.Api.Models;

public interface IEmployeeManager
{
    Task<List<Employee>> GetEmployeesAsync();
}
