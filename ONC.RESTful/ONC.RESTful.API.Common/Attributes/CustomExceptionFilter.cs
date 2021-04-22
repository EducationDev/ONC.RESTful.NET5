using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace ONC.RESTful.API.Common.Attributes
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="stack"></param>
        /// <returns></returns>
        private ApiError CreateHttpResponseMessage(HttpStatusCode code, string message, string stack)
        {
            var apiError = new ApiError(message)
            {
                Detail = stack,
                Code = code
            };
            return apiError;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            ApiError apiError = null;
            if (context.Exception is ApiException)
            {
                // handle explicit 'known' API errors
                var ex = context.Exception as ApiException;
                context.Exception = null;
                apiError = new ApiError(ex.Message)
                {
                    Errors = ex.Errors
                };

                context.HttpContext.Response.StatusCode = ex.StatusCode;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                apiError = new ApiError("Unauthorized Access");
                context.HttpContext.Response.StatusCode = 401;
                // handle logging here
            }
            else
            {
                // Unhandled errors
#if !DEBUG
                var msg = "An unhandled error occurred.";                
                string stack = null;
#else
                var message = context.Exception.GetBaseException().Message;
                var stack = context.Exception.StackTrace;

                var exceptionType = context.Exception.GetType().ToString();
                switch (exceptionType)
                {
                    case "System.Data.DuplicateNameException":

                        apiError = CreateHttpResponseMessage(HttpStatusCode.BadRequest, "Se encuentro un nombre de objeto de base de datos duplicado", stack);
                        break;

                    case "System.Data.ObjectNotFoundException":
                    case "System.Data.Entity.Core.ObjectNotFoundException":

                        apiError = CreateHttpResponseMessage(HttpStatusCode.NotFound, "No se encuentra el objeto solicitado.", stack);
                        break;

                    case "System.UnauthorizedAccessException":

                        apiError = CreateHttpResponseMessage(HttpStatusCode.Forbidden, "Excepción de acceso no autorizado", stack);
                        break;

                    case "System.ComponentModel.DataAnnotations.ValidationException":

                        apiError = CreateHttpResponseMessage(HttpStatusCode.BadRequest, "Se ha producido un error durante la validación de un campo de datos.", stack);
                        break;

                    case "System.Data.SqlClient.SqlException":
                        apiError = CreateHttpResponseMessage(HttpStatusCode.InternalServerError, "System.Data.SqlClient.SqlException", "El servicio lanzó una SqlException no controlada.");
                        break;

                    case "System.Data.Entity.Infrastructure.DbUpdateException":
                        apiError = CreateHttpResponseMessage(HttpStatusCode.InternalServerError, "Ha ocurrido un error. Por favor intente de nuevo.", stack);
                        break;

                    case "System.Data.Entity.Core.OptimisticConcurrencyException":
                    case "System.Data.OptimisticConcurrencyException":
                        apiError = CreateHttpResponseMessage(HttpStatusCode.InternalServerError, "Ha ocurrido un error. Por favor intente de nuevo. Si el error persiste, póngase en contacto con su administrador.", stack);
                        break;

                    default:
                        apiError = CreateHttpResponseMessage(HttpStatusCode.InternalServerError, $"{exceptionType}: El servicio lanzó una excepción no controlada.", stack);
                        break;
                }
#endif
                context.HttpContext.Response.StatusCode = (int)apiError.Code;
                // var loggerFactory = _serviceProvider.GetRequiredService<ILoggerFactory>();
                // handle logging here
            }

            // always return a JSON result
            context.Result = new JsonResult(apiError);

            base.OnException(context);
        }

    }

}