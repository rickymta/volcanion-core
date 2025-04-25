using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using System.Reflection;
using Volcanion.Core.Common.Abstractions;
using Volcanion.Core.Models.Attributes;
using Volcanion.Core.Models.Enums;

namespace Volcanion.Core.Presentation.Middlewares;

/// <summary>
/// VolcanionAuthMiddleware
/// </summary>
public class VolcanionAuthMiddleware
{
    /// <summary>
    /// RequestDelegate instance
    /// </summary>
    private readonly RequestDelegate _next;

    /// <summary>
    /// IJwtProvider instance
    /// </summary>
    private readonly IJwtProvider _jwtProvider;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="next"></param>
    /// <param name="configuration"></param>
    public VolcanionAuthMiddleware(RequestDelegate next, IJwtProvider jwtProvider)
    {
        _next = next;
        _jwtProvider = jwtProvider;
    }

    /// <summary>
    /// InvokeAsync method
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context)
    {
        // Get endpoint from context
        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;

        // If there is no endpoint, call the next middleware
        if (endpoint == null)
        {
            await _next(context);
            return;
        }

        // Check if there is an AllowAnonymous attribute, skip authentication
        if (endpoint.Metadata.GetMetadata<AllowAnonymousAttribute>() != null)
        {
            await _next(context);
            return;
        }

        // Get ControllerActionDescriptor from endpoint metadata
        var actionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();

        // If it is not an action descriptor, call the next middleware
        if (actionDescriptor == null)
        {
            await _next(context);
            return;
        }

        // Get VolcanionAuthAttribute from controller or method
        var volcanionAuthAttribute = actionDescriptor.ControllerTypeInfo.GetCustomAttribute<VolcanionAuthAttribute>() ?? actionDescriptor.MethodInfo.GetCustomAttribute<VolcanionAuthAttribute>();

        // If there is no VolcanionAuthAttribute, call the next middleware
        if (volcanionAuthAttribute != null)
        {
            // Get role from attribute
            var roleFromAttribute = volcanionAuthAttribute.Roles;

            // Check the token in the Authorization header
            if (context.Request.Headers.TryGetValue("Authorization", out var authorizationHeader) && authorizationHeader.ToString().StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                // Get the token from the header
                var token = authorizationHeader.ToString()["Bearer ".Length..].Trim();

                // Validate the token
                if (_jwtProvider.ValidateJwt(token, JwtType.AccessToken))
                {
                    // Decode the token
                    var (header, payload) = _jwtProvider.DecodeJwt(token);
                    // Get roles from claims
                    var rolesInClaims = payload?.ResourceAccess.RoleAccess.Roles;

                    // Compare roles in claims with roles in attribute
                    if (rolesInClaims != null && VerifyRole([.. rolesInClaims!], roleFromAttribute))
                    {
                        context.GetRouteData().Values.Add("AccountId", payload?.TokenId);
                        await _next(context);
                        return;
                    }
                }
            }
        }

        // Return 403 Forbidden
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        return;
    }


    /// <summary>
    /// VerifyRole
    /// </summary>
    /// <param name="rolesInClaims"></param>
    /// <param name="rolesInMethodOrController"></param>
    /// <returns>Role in claims has in or not in method, controller definition</returns>
    private static bool VerifyRole(string[]? rolesInClaims, string[]? rolesInMethodOrController)
    {
        // Return false if there is no role in claims or method or controller definition
        if (rolesInClaims == null || rolesInClaims.Length == 0 || rolesInMethodOrController == null || rolesInMethodOrController.Length == 0)
        {
            return false;
        }

        // Return true if there is any role in claims that is in method or controller definition
        return rolesInClaims.Intersect(rolesInMethodOrController).Any();
    }
}

/// <summary>
/// VolcanionAuthMiddlewareExtension
/// </summary>
public static class VolcanionAuthMiddlewareExtension
{
    /// <summary>
    /// UseVolcanionAuthMiddleware
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseVolcanionAuthMiddleware(this IApplicationBuilder builder)
    {
        // Return the builder with the middleware
        return builder.UseMiddleware<VolcanionAuthMiddleware>();
    }
}
