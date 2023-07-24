using IdentityGama.Authentication;
using IdentityGamaFramework.Authentication.Interface;
using System.Net;
using System.Web.Mvc;

namespace IdentityGama.Filters
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        private readonly IAuthenticationService _authorizationService = new AuthenticationService();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string authorizationHeader = filterContext.HttpContext.Request.Headers["Authorization"];
            string token = authorizationHeader.Substring("Bearer ".Length);

            if (_authorizationService.IsAuthenticated(token))
            {
                base.OnActionExecuting(filterContext); // Continue with the execution of the action
                return;
            }

            filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
        }


    }
}
