using Nancy;
using System.IO;

namespace Schedules.API
{
    public class DocsModule : NancyModule
    {
        public DocsModule()
        {
            Options["/api-docs"] = _ => Response.AllowCorsFor(Request);

            var jsonFile = Path.Combine("Docs", "resource-listing.json");
            Get["/api-docs"] = _ => Response.FromFile(jsonFile).AddCorsHeader();
        }
    }
}
