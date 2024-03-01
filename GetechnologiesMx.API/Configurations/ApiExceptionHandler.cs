using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GetechnologiesMx.API.Configurations
{
    public class ApiExceptionHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                if (context.Result is ObjectResult objectResult)
                {
                    var responseObject = new
                    {
                        Success = true,
                        Message = "Operación de la entidad exitosa.",
                        Data = objectResult.Value
                    };
                    context.Result = new ObjectResult(responseObject)
                    {
                        StatusCode = objectResult.StatusCode ?? 200
                    };
                }
            }
            else
            {
                // Exception occurred.
                var responseObject = new
                {
                    Success = false,
                    Message = "Ocurrió un error.",
                    Error = context.Exception.Message
                };
                context.Result = new ObjectResult(responseObject)
                {
                    StatusCode = 500
                };
                context.ExceptionHandled = true;
            }

        }
    }
}