namespace PlugAndPlay.Api.Managers;

using PlugAndPlay.Api.Providers;
using PlugAndPlay.Api.Models;
using PlugAndPlay.Api.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class HelloManager
{
    private readonly IHelloProvider _provider;

    public HelloManager(IHelloProvider provider)
    {
        _provider = provider;
    }

    // Call the HelloProvider and return a ManagerResult<List<HelloDto>> wrapped in a Task
    public Task<ManagerResult<List<object>>> GetFewRecords()
    {
        var items = _provider.GetFewRecords()?.ToList() ?? new List<object>();
        var result = new ManagerResult<List<object>>(items, true, "OK", ResponseCode.SUCCESS);
        return Task.FromResult(result);
    }

    public Task<ManagerResult<List<object>>> GetTwoRows()
    {
        var items = _provider.GetTwoRows().ToList();
        var result = new ManagerResult<List<object>>(items, true, "OK", ResponseCode.SUCCESS);
        return Task.FromResult(result);
    }

    public Task<ManagerResult<List<object[]>>> GetTwoArrays()
    {
        var items = _provider.GetTwoArrays().ToList();
        var result = new ManagerResult<List<object[]>>(items, true, "OK", ResponseCode.SUCCESS);
        return Task.FromResult(result);
    }
}