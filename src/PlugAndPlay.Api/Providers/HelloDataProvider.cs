namespace PlugAndPlay.Api.Providers;

using System.Collections.Generic;
using PlugAndPlay.Api.DTOs;
using PlugAndPlay.Api.Models;
using Microsoft.EntityFrameworkCore;
using PlugAndPlay.Api.Data;


public class HelloProvider : IHelloProvider
{
    private readonly AppDbContext _context;

    public HelloProvider(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }
    public IEnumerable<object> GetFewRecords()
    {
        var obj = new List<object>
        {
            new { Id = 1, Name = "Malhar" },
            new { Id = 2, Name = "Tanksale" }
        };
        return obj;
    }

    public IEnumerable<object> GetTwoRows()
    {
        var obj = new List<object>
        {
            new {Id = 1, Name = "Malhar"},
            new {Id = 2, Name = "Rudra"}
        };
        return obj;
    }
    //Creating an object array

    public IEnumerable<object[]> GetTwoArrays()
    {
        return new List<object[]>
    {
        new object[] { 1, "Malhar" },
        new object[] { 2, "Rudra" }
    };
    }


    public async Task<bool> TestConnectionAsync()

    {
        try
        {
            // Simple query to test DB connection
            var canConnect = await _context.Database.CanConnectAsync();
            return canConnect;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }


    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<List<Order>> GetOrders()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<List<object>> GetOrdersWithUsers()
    {
        var data = await _context.Orders
            .Include(o => o.User)
            .Include(o => o.Product)
            .Select(o => new
            {
                FullName = o.User.FullName,
                Quantity = o.Quantity,
                ProductName = o.Product.Name,
                Price = o.Product.Price,
                OrderDate = o.OrderDate
            })
            .ToListAsync();

        return data.Cast<object>().ToList(); // ✔ return ONLY List<object>
    }

}
