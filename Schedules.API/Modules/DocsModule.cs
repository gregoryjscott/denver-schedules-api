using Nancy;
using System.IO;

public class DocsModule : NancyModule
{
    public DocsModule()
    {
        Get["/api-docs"] = _ => FromJsonFile("resource-listing.json");
        Get["/api-docs/schedules"] = _ => FromJsonFile("schedules.json");
        Get["/api-docs/reminders"] = _ => FromJsonFile("reminders.json");
    }

    static Response FromJsonFile(string jsonFile)
    {
        var json = File.ReadAllText(Path.Combine("Docs", jsonFile));
        var response = (Response)json;
        response.ContentType = "application/json";
        return response.WithHeader("Access-Control-Allow-Origin", "*");
    }
}