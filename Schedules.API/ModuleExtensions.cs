using Nancy;
using System.IO;
using System;

namespace Schedules.API
{
    public static class ModuleExtensions
    {
        public static void SetupDocs(this NancyModule module, string resource)
        {
            var jsonFile = Path.Combine("Docs", String.Format("{0}.json", resource));
            var route = String.Format("/api-docs/{0}", resource);
            module.Options[route] = _ => new Response().AddPreflightCorsHeadersUsing(module.Request.Headers);
            module.Get[route] = _ => FromJsonFile(module, jsonFile).AddCorsHeader();
        }

        public static Response FromJsonFile(this NancyModule module, string jsonFile)
        {
            var json = File.ReadAllText(jsonFile);
            var response = (Response)json;
            response.ContentType = "application/json";
            return response;
        }
    }
}
