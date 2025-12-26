namespace PlugAndPlay.Api.Providers;

using PlugAndPlay.Api.Models;
using PlugAndPlay.Api.Data;
using Microsoft.EntityFrameworkCore;

public class EmployeeProvider : IEmployeeProvider
{
    private readonly AppDbContext _context;

    public EmployeeProvider(AppDbContext context)
    {
        _context = context;
    }

    // ⚠️ THIS SIGNATURE MUST MATCH THE INTERFACE EXACTLY
    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }
    //This is ISP Principle
}
