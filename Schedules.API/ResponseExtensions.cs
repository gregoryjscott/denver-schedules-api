using Nancy;
using System;

namespace Schedules.API
{
    public static class ResponseExtensions
    {
        public static Response AddPreflightCorsHeadersUsing(this Response response, RequestHeaders requestHeaders)
        {
            var requested = requestHeaders["Access-Control-Request-Headers"];
            var allowHeaders = String.Join(", ", requested);
            return response
                .WithHeader("Access-Control-Allow-Origin", "*")
                .WithHeader("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, PATCH, OPTIONS")
                .WithHeader("Access-Control-Allow-Headers", allowHeaders);
        }

        public static Response AddCorsHeader(this Response response)
        {
            return response.WithHeader("Access-Control-Allow-Origin", "*");
        }
    }
}