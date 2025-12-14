namespace PlugAndPlay.Api.Providers;

using System.Collections.Generic;
using PlugAndPlay.Api.DTOs;
using PlugAndPlay.Api.Models;

public interface IHelloProvider
{
    IEnumerable<object> GetFewRecords();
    IEnumerable<object> GetTwoRows();

    IEnumerable<object[]> GetTwoArrays();

    Task<bool> TestConnectionAsync();
    Task<List<Employee>> GetEmployeesAsync();
    Task<List<Order>> GetOrders();

    Task<List<object>> GetOrdersWithUsers();
}
