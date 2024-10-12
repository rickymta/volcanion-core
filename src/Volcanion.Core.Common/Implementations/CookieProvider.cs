using Microsoft.AspNetCore.Http;
using Volcanion.Core.Common.Abstractions;

namespace Volcanion.Core.Common.Implementations
{
    /// <summary>
    /// CookieProvider
    /// </summary>
    public class CookieProvider : ICookieProvider
    {
        /// <summary>
        /// IHttpContextAccessor
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public CookieProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Set cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        public void Set(string key, string value, int? expireTime = 3600)
        {
            expireTime ??= 3600;

            var option = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(expireTime.Value)
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, option);
        }

        /// <summary>
        /// Get cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies[key];
        }

        /// <summary>
        /// Remove cookie by key
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }

        /// <summary>
        /// Remove all cookie
        /// </summary>
        public void RemoveAlls()
        {
            foreach (string key in _httpContextAccessor.HttpContext.Request.Cookies.Keys)
            {
                Remove(key);
            }
        }
    }
}
