using System;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using ShopBridge.Auth;
using System.Threading;

namespace ShopBridge.Filters
{
    /// <summary>
    /// Authorization Filter class to authorize the user api calls coming from [Currently authorization not implemented but full code is there]
    /// </summary>

    public class BasicAuthorizationAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Authorization Filter to Check validity of the user.
        /// </summary>
        /// <param name="actionContext">Http Action Context</param>
        /// <returns></returns>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.Authorization == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                    string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                    string[] userNamePassArray = decodedAuthenticationToken.Split(':');
                    string userName = userNamePassArray[0];
                    string password = userNamePassArray[1];

                    if (InventoryAuth.Login(userName, password))
                    {
                        // storing in thread principle so that on further extension to this app, we can make access to edit/update/delete to owner only.
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }

                }
            }
            catch
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }
        }
    }
}