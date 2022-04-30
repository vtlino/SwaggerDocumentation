using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;
using SwaggerDocumentation.Domain.Response;
using System.Text.Json;

namespace SwaggerDocumentation.Api.Filters
{
    public class ActionFilterExecuting : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var correlationIdValid = context.HttpContext.Request.Headers.TryGetValue("x-correlation-id", out StringValues headerCorrelationId);
                
                if (!correlationIdValid)
                {
                    context.Result = new BadRequestObjectResult(new ErrorResponse 
                    { Errors = new List<ErrorData> { new ErrorData { Code = "EBR000", Message = "Header x-correlation-id invalid."} } });
                    return;
                }

                if (!context.ModelState.IsValid && context.ModelState.ErrorCount > 0)
                {
                    var errors = GetErrorModelState(context.ModelState);
                    context.Result = new BadRequestObjectResult(errors);
                    return;
                }
            }
            catch (Exception ex)
            {
                //TODO: log
                Console.WriteLine(ex.Message?.ToString());
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //TODO: log
            var result = context.Result as ObjectResult == null ? "Response null" : JsonSerializer.Serialize(((ObjectResult)context.Result).Value);
            Console.WriteLine(result);
        }

        private ErrorResponse GetErrorModelState(ModelStateDictionary modelState)
        {
            ErrorResponse errorResponse = new ErrorResponse();

            foreach (var item in modelState.Keys)
            {
                if (modelState[item]?.Errors.Count > 0)
                {
                    if (item.Equals("$"))
                    {
                        errorResponse.Errors.Add(new ErrorData { Code = "EBR001", Message = "Invalid body request." });
                        continue;
                    }

                    var field = item.Split("$.");
                    if (modelState[item].Errors[0].ErrorMessage.Contains("is required"))
                    {
                        errorResponse.Errors.Add(new ErrorData { Code = "EBR002", Message = $"Field {field.LastOrDefault()} is required" });
                    }
                    else
                    {
                        errorResponse.Errors.Add(new ErrorData { Code = "EBR003", Message = $"Field {field.LastOrDefault()} is invalid" });
                    }
                }
            }

            return errorResponse;
        }
    }
}