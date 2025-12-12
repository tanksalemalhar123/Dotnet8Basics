using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PlugAndPlay.Api.Models;

namespace PlugAndPlay.Api.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected IActionResult BuildResponse(ResponseCode code, object? data = null, string? message = null, ModelStateDictionary? modelState = null)
    {
        if (modelState != null && !modelState.IsValid)
        {
            var errors = modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(new ResponseModel { Code = ResponseCode.BAD_REQUEST, Message = string.Join(" | ", errors) });
        }

        if (data == null)
            return StatusCode((int)code, new ResponseModel { Code = code, Message = message ?? (code == ResponseCode.SUCCESS ? "Success" : "Failure") });

        // Return typed ResponseModel<T>
        var responseType = typeof(ResponseModel<>).MakeGenericType(data.GetType());
        var response = (ResponseModel)Activator.CreateInstance(responseType)!;
        response.Code = code;
        response.Message = message ?? (code == ResponseCode.SUCCESS ? "Success" : "Failure");
        responseType.GetProperty(nameof(ResponseModel<object>.Data))!.SetValue(response, data);

        return StatusCode((int)code, response);
    }

    protected IActionResult ConvertManagerResultToBuildResponse<T>(ManagerResult<T> result)
    {
        if (result == null)
            return BuildResponse(ResponseCode.INTERNAL_ERROR, message: "Null result from manager");

        if (!result.IsSuccess)
            return BuildResponse(result.Code, message: result.ErrorMessage);

        return BuildResponse(result.Code, data: result.Data);
    }
}
