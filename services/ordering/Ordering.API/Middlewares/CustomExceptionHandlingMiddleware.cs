using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Exceptions;
using Ordering.Application.Exceptions;

public sealed class CustomExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException ex)
        {
            await WriteProblemDetails(
                context,
                HttpStatusCode.BadRequest,
                "Validation error",
                ex.Errors
            );
        }
        catch (NotFoundException ex)
        {
            await WriteProblemDetails(
                context,
                HttpStatusCode.NotFound,
                "Resource not found",
                ex.Message
            );
        }
        catch (Exception ex)
        {
            await WriteProblemDetails(
                context,
                HttpStatusCode.InternalServerError,
                "Server error",
                "An unexpected error occurred."
            );
        }
    }

    private static async Task WriteProblemDetails(
        HttpContext context,
        HttpStatusCode statusCode,
        string title,
        object? errors)
    {
        var problemDetails = new ProblemDetails
        {
            Status = (int)statusCode,
            Title = title,
            Detail = errors is string ? errors.ToString() : null
        };

        if (errors is not string && errors is not null)
        {
            problemDetails.Extensions["errors"] = errors;
        }

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsJsonAsync(problemDetails);
    }
}