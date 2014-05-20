using Nancy;
using Nancy.ModelBinding;
using Schedules.API.Models;

namespace Schedules.API
{
    public class RemindersModule : NancyModule
    {
        public RemindersModule()
        {
            this.SetupDocsFor("reminders");

            Options["/reminders"] = _ => Response.AllowCorsFor(Request);

            Post["/reminders"] = _ => { 
                Reminder reminder = this.Bind<Reminder>();
                return Response.AsJson(reminder, HttpStatusCode.Created)
                    .AddCorsHeader();
            };
        }
    }
}
