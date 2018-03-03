using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MvcPostComments
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "PostApi",
                routeTemplate: "api/posts/{action}",
                defaults: new { controller = "PostApi" }
            );

            config.Routes.MapHttpRoute(
                name: "PostDeleteApi",
                routeTemplate: "api/posts/{action}/{postId}",
                defaults: new { controller = "PostApi", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CommentApi",
                routeTemplate: "api/comments/{action}/{id}",
                defaults: new { controller = "CommentApi", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CommentsApi",
                routeTemplate: "api/comments/{action}",
                defaults: new { controller = "CommentApi" }
            );

            config.Routes.MapHttpRoute(
                name: "Action",
                routeTemplate: "api/{controller}/{action}/{postId}",
                defaults: new { postId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
