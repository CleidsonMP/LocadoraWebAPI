using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Locadora.Services
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                //çasfjdçjsfllçfjlkf
                string authenticationToken = actionContext.Request
                    .Headers.Authorization.Parameter;
                //macoratti:numsey
                string decodedAuthenticationToken = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authenticationToken));

                string[] usernamePassordArray = decodedAuthenticationToken.Split(':');

                string username = usernamePassordArray[0];
                string password = usernamePassordArray[1];

                if (FuncionariosSeguranca.Login(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                       .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}