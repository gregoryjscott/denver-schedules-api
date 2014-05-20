using Nancy;
using System.IO;

namespace Schedules.API
{
    public class DocsModule : NancyModule
    {
        public DocsModule()
        {
            var jsonFile = Path.Combine("Docs", "resource-listing.json");
            Options["/api-docs"] = _ => new Response().AddPreflightCorsHeadersUsing(Request.Headers);
            Get["/api-docs"] = _ => this.FromJsonFile(jsonFile).AddCorsHeader();
        }
    }
}
