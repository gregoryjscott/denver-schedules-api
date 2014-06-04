using Nancy;
using Nancy.ModelBinding;
using Schedules.API.Models;
using Centroid;

public class JaggerModule : NancyModule
{
    public JaggerModule() {}
    public JaggerModule(string apiDeclaration)
    {
        dynamic resource = new Config(apiDeclaration);
        foreach (dynamic api in resource.apis)
        {
            foreach (dynamic operation in api.operations)
            {
                if (operation.method == "POST")
                {
                    var path = (string)api.path;
                    Post[path] = _ => {
                        Reminder reminder = this.Bind<Reminder>();
                        return Response.AsJson(reminder, HttpStatusCode.Created);
                    };
                }
            }
        }
    }
}
