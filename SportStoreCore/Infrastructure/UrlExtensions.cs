using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreCore.Infrastructure
{
    /*
    The PathAndQuery  extension method operates on the  HttpRequest  class, which ASP.NET uses to describe
    an HTTP request. The extension method generates a URL that the browser will be returned to after the cart has
    been updated, taking into account the query string if there is one.
     * */

    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest httpRequest) =>
            httpRequest.QueryString.HasValue ? $"{httpRequest.Path}{httpRequest.QueryString}" : httpRequest.Path.ToString();
    }
}
