using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace LottoLite.Web.ActionFilters
{
        public class ApiGlobalExceptionFilter : ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext filterContext)
            {
                filterContext.ActionContext.ModelState.AddModelError("General", string.Format("Sorry, something went wrong! {0}", DateTime.UtcNow.ToString("yyMMddHHmmss")));

                Exception ex = filterContext.Exception ?? new Exception("No further information exists.");
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

                throw new HttpResponseException(filterContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, filterContext.ActionContext.ModelState));
            }
        }
}