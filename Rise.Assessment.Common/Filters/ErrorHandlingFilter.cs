using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Rise.Assessment.Common.Filters
{
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ErrorHandlingFilter));

        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            log.Fatal(exception.Message, exception);
            context.ExceptionHandled = false;
        }
    }
}
