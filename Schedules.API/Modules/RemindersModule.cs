using Nancy;
using Nancy.ModelBinding;
using Schedules.API.Models;
using Centroid;
using System.Linq;

public class RemindersModule : NancyModule
{
    public RemindersModule()
    {
        dynamic reminders = Config.FromFile("Docs/reminders.json");
        foreach (dynamic api in reminders.apis)
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

//        Post ["/reminders"] = _ => {
//            Reminder reminder = this.Bind<Reminder>();
//            return Response.AsJson(reminder, HttpStatusCode.Created);
//        };
    }
}
