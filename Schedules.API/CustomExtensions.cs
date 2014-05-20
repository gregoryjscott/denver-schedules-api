using Nancy;
using System.IO;
using System;

namespace Schedules.API
{
    public static class CustomExtensions
    {
        public static void SetupDocsFor(this NancyModule module, string resource)
        {
            var jsonFile = Path.Combine("Docs", String.Format("{0}.json", resource));
            var route = String.Format("/api-docs/{0}", resource);
            module.Options[route] = _ => module.Response.AllowCorsFor(module.Request);
            module.Get[route] = _ => FromFile(module.Response, jsonFile).AddCorsHeader();
        }

        public static Response FromFile(this IResponseFormatter responseFormatter, string jsonFile)
        {
            var json = File.ReadAllText(jsonFile);
            var response = (Response)json;
            response.ContentType = "application/json";
            return response;
        }

        public static Response AllowCorsFor(this IResponseFormatter responseFormatter, Request request)
        {
            var requested = request.Headers["Access-Control-Request-Headers"];
            var allowHeaders = String.Join(", ", requested);
            return new Response()
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
