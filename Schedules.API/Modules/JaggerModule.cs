using Nancy;
using Schedules.API;
using Centroid;
using Simpler;

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
                    Post[path] = parameters => {
                        var createReminder = Task.New<CreateReminder>();
                        createReminder.In.Module = this;
                        createReminder.In.Parameters = parameters;
                        createReminder.Execute();
                        return createReminder.Out.Response;
                    };
                }
            }
        }
    }
}
