using Nancy;
using Centroid;

public class DocsModule : NancyModule
{
    public DocsModule()
    {
        StaticConfiguration.DisableErrorTraces = false;

        Get ["/api-docs"] = _ => {
            var resourceListing = Config.FromFile("Docs/resource-listing.json");
            return Response.AsJson(resourceListing);
        };

        Get ["/api-docs/schedules"] = _ => {
            var schedules = Config.FromFile("Docs/schedules.json");
            return Response.AsJson(schedules);
        };
    }
}