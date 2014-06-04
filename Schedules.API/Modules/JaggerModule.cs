using Nancy;
using Schedules.API;
using Centroid;
using Simpler;
using System;

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
                var path = (string)api.path;
                var jaggerTask = FindJaggerTask(ToPascalCase((string)operation.nickname));
                Func<dynamic, dynamic> action = parameters => {
                    jaggerTask.In.Module = this;
                    jaggerTask.In.Parameters = parameters;
                    jaggerTask.Execute();
                    return jaggerTask.Out.Response;
                };

                if (operation.method == "POST")
                {
                    Post[path] = action;
                }
            }
        }
    }

    static JaggerTask FindJaggerTask(string name)
    {
        return Task.New<CreateReminder>();
    }

    static string ToPascalCase(string camelCase)
    {
        if (camelCase.Length == 0) return camelCase;
        if (camelCase.Length == 1) return camelCase.ToUpper();

        return String.Concat(camelCase.Substring(0, 1).ToUpper(), camelCase.Substring(1));
    }
}
