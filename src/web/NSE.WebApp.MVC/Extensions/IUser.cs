﻿using System.Security.Claims;

namespace NSE.WebApp.MVC.Extensions
{
    public interface IUser
    {
        string Name { get; }
        Guid ObterUserId();
        string ObterUserEmail();
        string ObterUserToken();
        bool EstaAutenticado();
        bool PossuiRole(string role);
        IEnumerable<Claim> ObterClaims();
        HttpContext ObterHttpContext();
    }

    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public string Name => _contextAccessor.HttpContext.User.Identity.Name;
        public AspNetUser(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public bool EstaAutenticado()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> ObterClaims()
        {
            return _contextAccessor.HttpContext.User.Claims;
        }

        public HttpContext ObterHttpContext()
        {
            return _contextAccessor.HttpContext;
        }

        public string ObterUserEmail()
        {
            return EstaAutenticado() ? _contextAccessor.HttpContext.User.GetUserEmail() : string.Empty;
        }

        public Guid ObterUserId()
        {
            return EstaAutenticado() ? Guid.Parse(_contextAccessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string ObterUserToken()
        {
            return EstaAutenticado() ? _contextAccessor.HttpContext.User.GetUserToken() : string.Empty;
        }

        public bool PossuiRole(string role)
        {
            return _contextAccessor.HttpContext.User.IsInRole(role);
        }
    }

    public static class ClaimsPrincipalExtensions
    {

        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentNullException(nameof(principal));

            var claim = principal.FindFirst("sub");
            return claim?.Value;
        }
        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentNullException(nameof(principal));

            var claim = principal.FindFirst("email");
            return claim?.Value;
        } 
        
        public static string GetUserToken(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentNullException(nameof(principal));

            var claim = principal.FindFirst("JWT");
            return claim?.Value;
        }
    }
}
