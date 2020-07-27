using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Fonour.MVC.Common.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext filterContext)
        {
            var log = new StringBuilder();

            //log the url
            if (filterContext.HttpContext.Request.GetDisplayUrl() != null)
                log.AppendLine(filterContext.HttpContext.Request.GetDisplayUrl());

            log.AppendLine($"\tIP: {filterContext.HttpContext.Connection.RemoteIpAddress}");

            foreach (var key in filterContext.HttpContext.Request.Headers.Keys)
            {
                log.AppendLine($"\t{key}: {filterContext.HttpContext.Request.Headers[key]}");
            }

            var exception = filterContext.Exception;
            log.AppendLine("\tError Message:" + exception.Message);
            if (exception.InnerException != null)
            {
                PrintInnerException(exception.InnerException, log);
            }
            log.AppendLine("\tError HelpLink:" + exception.HelpLink);
            log.AppendLine("\tError StackTrace:" + exception.StackTrace);

            _logger.LogError(log.ToString());
        }


        private void PrintInnerException(Exception ex, StringBuilder log)
        {
            log.AppendLine("\tError InnerMessage:" + ex.Message);
            if (ex.InnerException != null)
            {
                PrintInnerException(ex.InnerException, log);
            }
        }
    }
}
