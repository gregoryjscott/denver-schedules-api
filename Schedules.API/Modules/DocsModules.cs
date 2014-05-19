using Nancy;
using Nancy.Responses;
using Centroid;
using System.IO;

public class DocsModule : NancyModule
{
    public DocsModule()
    {
        StaticConfiguration.DisableErrorTraces = false;

        Get ["/"] = _ => View["index.html"];

        Get["/lib/{all*}"] = parameters => {
            var fileName = (string)parameters.all;
            return new GenericFileResponse(Path.Combine("Docs", "lib", fileName));
        };

        Get["/css/{all*}"] = parameters => {
            var fileName = (string)parameters.all;
            return new GenericFileResponse(Path.Combine("Docs", "css", fileName));
        };

        Get["/images/{all*}"] = parameters => {
            var fileName = (string)parameters.all;
            return new GenericFileResponse(Path.Combine("Docs", "images", fileName));
        };

        Get["/js/{all*}"] = parameters => {
            var fileName = (string)parameters.all;
            return new GenericFileResponse(Path.Combine("Docs", "js", fileName));
        };

        Get ["/api-docs"] = _ => {
            dynamic resourceListing = Config.FromFile("Docs/resource-listing.json");
            return Response.AsJson(new {
                apiVersion = resourceListing.apiVersion,
                swaggerVersion = resourceListing.swaggerVersion,
                apis = resourceListing.apis,
                info = resourceListing.info
            });
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
                models = schedules.models
            };
            return Response.AsJson(response);
        };
    }
}