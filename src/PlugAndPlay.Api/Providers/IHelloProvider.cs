namespace PlugAndPlay.Api.Providers;

using System.Collections.Generic;
using PlugAndPlay.Api.DTOs;

public interface IHelloProvider
{
    IEnumerable<object> GetFewRecords();
    IEnumerable<object> GetTwoRows();

    IEnumerable<object[]> GetTwoArrays();
}
