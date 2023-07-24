using IdentityGama.Authorization;
using IdentityGama.Interface.Authorization;
using System.Net;
using System.Web.Mvc;

namespace IdentityGama.Filters
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public string Role { get; set; }
        private readonly IAuthorizationService _authorizationService = new AuthorizationService();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string authorizationHeader = filterContext.HttpContext.Request.Headers["Authorization"];

            string role = Role;

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                string token = authorizationHeader.Substring("Bearer ".Length);

                if (_authorizationService.IsAuthorized(token, role))
                {
                    base.OnActionExecuting(filterContext); // Continue with the execution of the action
                    return;
                }
            }

            filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        }


    }
}
