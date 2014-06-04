using Nancy;
using Centroid;
using System.Reflection;
using Simpler.Core.Tasks;
using System;
using System.Linq;

namespace Jagger
{
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
                    var nickname = ToPascalCase((string)operation.nickname);
                    var jaggerTask = FindJaggerTask(nickname, Assembly.GetAssembly(GetType()));
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

        static JaggerTask FindJaggerTask(string name, Assembly assembly)
        {
            var taskType = assembly.GetTypes().SingleOrDefault(t => t.Name == name);
            if (taskType == null) throw new Exception(String.Format("Can't find {0}!", name));

            var createTask = new CreateTask { In = { TaskType = taskType } };
            createTask.Execute();
            return (JaggerTask)createTask.Out.TaskInstance;
        }

        static string ToPascalCase(string camelCase)
        {
            if (camelCase.Length == 0) return camelCase;
            if (camelCase.Length == 1) return camelCase.ToUpper();

            return String.Concat(camelCase.Substring(0, 1).ToUpper(), camelCase.Substring(1));
        }
    }
}
