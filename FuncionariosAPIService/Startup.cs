using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Locadora.Startup))]
namespace Locadora
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // configuracao WebApi
        var config = new HttpConfiguration();
 
        // configurando rotas
        config.MapHttpAttributeRoutes();
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
        // ativando cors
        app.UseCors(CorsOptions.AllowAll);

       
        // ativando configuração WebApi
        app.UseWebApi(config);
        }

        
    }
}
