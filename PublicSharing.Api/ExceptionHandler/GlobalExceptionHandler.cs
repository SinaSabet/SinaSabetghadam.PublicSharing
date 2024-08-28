using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PublicSharing.Api.Model;
using PublicSharing.Domain.DomainItems;
using System.Net;

namespace PublicSharing.Api.ExceptionHandler
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            logger.LogError(
           exception, "Exception occurred: {Message}", exception.Message);

            ApiResponse problemDetails = CreateProblemDetailFromException(exception);

            httpContext.Response.StatusCode = problemDetails.Status;

            await httpContext.Response
        .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }


        private static ApiResponse CreateProblemDetailFromException(Exception exception)
        {
            return exception is DomainException || exception is ValidationException 
                ? new ApiResponse
                {
                    Succeeded = false,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Bad Request",
                    Errors = new List<string> { exception.Message }
                }
                : new ApiResponse
                {
                    Succeeded = false,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Server error",
                    Errors = new List<string> { "Server error" }
                };
        }
    }


}