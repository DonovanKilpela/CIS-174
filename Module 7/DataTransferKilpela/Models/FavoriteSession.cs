using DataTransferKilpela.Controllers;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DataTransferKilpela.Models
{
    public static class FavoriteSession
    {
        private const string FavoritesKey = "favorites";

        public static void SetFavorites(HttpContext httpContext, List<Country> favorites)
        {
            // This will make the cookie last for 30 days 
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30),
                IsEssential = true,
                HttpOnly = true,
                Secure = true
            };

            string favoritesJson = JsonSerializer.Serialize(favorites);
            httpContext.Response.Cookies.Append(FavoritesKey, favoritesJson, options);
        }

        // This will retrieve the list of favorite countries from the cookie.
        public static List<Country> GetFavorites(HttpContext httpContext)
        {
            string favoritesJson = httpContext.Request.Cookies[FavoritesKey]!;
            return string.IsNullOrEmpty(favoritesJson)
                ? new List<Country>()
                : JsonSerializer.Deserialize<List<Country>>(favoritesJson)!;
        }

        // This will clear the favorites and delete the cookie 
        public static void ClearFavorites(HttpContext httpContext)
        {
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1),
                IsEssential = true,
                HttpOnly = true,
                Secure = true
            };

            httpContext.Response.Cookies.Delete(FavoritesKey);
            httpContext.Response.Cookies.Append(FavoritesKey, "", options);
        }
    }
}
