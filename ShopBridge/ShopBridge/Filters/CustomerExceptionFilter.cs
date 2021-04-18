﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace ShopBridge.Filters
{
    /// <summary>
    /// Exception Filter class to for any exception occuring in the api calls
    /// </summary>
    
    public class CustomerExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent($"An unhandled exception was thrown by service. Exception: {actionExecutedContext.Exception.ToString()}"),  
                    ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            };
            actionExecutedContext.Response = response;
        }
    }
}