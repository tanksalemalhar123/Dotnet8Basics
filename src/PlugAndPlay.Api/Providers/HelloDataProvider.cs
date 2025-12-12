namespace PlugAndPlay.Api.Providers;

using System.Collections.Generic;
using PlugAndPlay.Api.DTOs;

public class HelloProvider : IHelloProvider
{
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
}
