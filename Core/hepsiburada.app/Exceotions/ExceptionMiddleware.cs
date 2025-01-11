﻿using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace hepsiburada.app.Exceotions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext Httpcontext, RequestDelegate next)
        {
            try
            {
                await next(Httpcontext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(Httpcontext, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            List<string> errors = new()
                {
                    exception.Message,
                    exception.InnerException?.ToString()
                };

            return httpContext.Response.WriteAsync(new ExceptionModel
            {
                Errors = errors,
                StatusCode = statusCode

            }.ToString());
        }

        private static int GetStatusCode(Exception exception) =>
             exception switch
             {
                 BadRequestException => StatusCodes.Status400BadRequest,
                 NotFoundException => StatusCodes.Status404NotFound,
                 ValidationException => StatusCodes.Status422UnprocessableEntity,
                 _ => StatusCodes.Status500InternalServerError
             };

    }
}
