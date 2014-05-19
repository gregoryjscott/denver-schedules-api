using Nancy;
using Centroid;

public class DocsModule : NancyModule
{
    public DocsModule()
    {
        Get ["/api-docs"] = _ => {
            dynamic resourceListing = Config.FromFile("Docs/resource-listing.json");
            return Response.AsJson(new {
                apiVersion = resourceListing.apiVersion,
                swaggerVersion = resourceListing.swaggerVersion,
                apis = resourceListing.apis,
                info = resourceListing.info
            }).WithHeader("Access-Control-Allow-Origin", "*");
        };

        Get ["/api-docs/schedules"] = _ => {
            dynamic schedules = Config.FromFile("Docs/schedules.json");
            var response = new {
                apiVersion = schedules.apiVersion,
                swaggerVersion = schedules.swaggerVersion,
                basePath = schedules.basePath,
                resourcePath = schedules.resourcePath,
                produces = schedules.produces,
                authorizations = schedules.authorizations,
                apis = schedules.apis,
                models = new {
                    schedule = new {
                        id = schedules.models.Schedule.id,
                        properties = new {
                            title = new {
                                type = schedules.models.schedule.properties.title.type,
                            }
                        }
                    }
                }
            };
            return Response.AsJson(response).WithHeader("Access-Control-Allow-Origin", "*");
        };
    }
}