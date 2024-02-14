using BancoAPI.Filters.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BancoAPI.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            switch (exception)
            {
                case SaldoInconsistenteException saldoInconsistenteException:
                    context.Result = new ContentResult
                    {
                        Content = saldoInconsistenteException.Message,
                        StatusCode = (int)HttpStatusCode.UnprocessableEntity,
                        ContentType = "text/plain"
                    };
                    break;

                case BadRequestException badRequestException:
                    context.Result = new ContentResult
                    {
                        Content = badRequestException.Message,
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        ContentType = "text/plain"
                    };
                    break;

                case NotFoundException notFoundException:
                    context.Result = new ContentResult
                    {
                        Content = notFoundException.Message,
                        StatusCode = (int)HttpStatusCode.NotFound,
                        ContentType = "text/plain"
                    };
                    break;

                default:
                    context.Result = new ContentResult
                    {
                        Content = exception.Message + exception.StackTrace,
                        StatusCode = (int)HttpStatusCode.InternalServerError,
                        ContentType = "text/plain"
                    };
                    break;

            }
        }
    }
}
