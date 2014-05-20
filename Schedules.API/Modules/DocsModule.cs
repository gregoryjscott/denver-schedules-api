using Nancy;
using System;
using System.IO;

namespace Schedules.API
{
    public class DocsModule : NancyModule
    {
        public DocsModule()
        {
            Get["/api-docs"] = _ => this.FromJsonFile("resource-listing.json").AddCorsHeader();
            Get["/api-docs/schedules"] = _ => this.FromJsonFile("schedules.json").AddCorsHeader();
            Get["/api-docs/reminders"] = _ => this.FromJsonFile("reminders.json").AddCorsHeader();

            Options["/api-docs"] = _ => new Response().AddPreflightCorsHeaders(this.Request);
            Options["/api-docs/schedules"] = _ => new Response().AddPreflightCorsHeaders(this.Request);
            Options["/api-docs/reminders"] = _ => new Response().AddPreflightCorsHeaders(this.Request);
            Options["/schedules"] = _ => new Response().AddPreflightCorsHeaders(this.Request);
            Options["/reminders"] = _ => new Response().AddPreflightCorsHeaders(this.Request);
        }
    }
}

namespace Schedules.API
{
    public static class ModuleExtensions
    {
        public static Response FromJsonFile(this NancyModule module, string jsonFile)
        {
            var json = File.ReadAllText(Path.Combine("Docs", jsonFile));
            var response = (Response)json;
            response.ContentType = "application/json";
            return response;
        }
    }
}

namespace Schedules.API
{
    public static class ResponseExtensions
    {
        public static Response AddPreflightCorsHeaders(this Response response, Request request)
        {
            var requestHeaders = request.Headers["Access-Control-Request-Headers"];
            var allowHeaders = String.Join(", ", requestHeaders);
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