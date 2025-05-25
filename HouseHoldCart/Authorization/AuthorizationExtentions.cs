using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HouseHoldCart.Authorization
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddHouseHoldCartAuthorization(this IServiceCollection services)
        {
            //services.AddAuthorizationBuilder()
            //    .AddPolicy("PermissionKey", policy => policy.Requirements.Add(new Requirement())) - register your custom authorization requirement here
                

            //services.AddScoped<IAuthorizationHandler, Handler>(); - register your custom authorization handler here

            return services;
        }

        public static RouteValueDictionary GetRouteValues(this AuthorizationHandlerContext context)
        {
            if (context.Resource is AuthorizationFilterContext authorizationFilterContext)
                return authorizationFilterContext.RouteData.Values;
            else if (context.Resource is RouteValueDictionary routevalueDictionary)
                return routevalueDictionary;
            else if (context.Resource is Microsoft.AspNetCore.Http.HttpContext httpContext)
                return httpContext.GetRouteData()?.Values;

            throw new AuthenticationFailureException("Cannot resolve RouteValueDictionary");
        }
    }
}
