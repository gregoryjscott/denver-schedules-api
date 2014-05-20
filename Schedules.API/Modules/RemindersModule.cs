using Nancy;
using Nancy.ModelBinding;
using Schedules.API.Models;

namespace Schedules.API
{
    public class RemindersModule : NancyModule
    {
        public RemindersModule()
        {
            this.SetupDocs("reminders");

            Options["/reminders"] = _ => new Response().AddPreflightCorsHeadersUsing(Request.Headers);

            Post["/reminders"] = _ => { 
                Reminder reminder = this.Bind<Reminder>();
                return Response.AsJson(reminder, HttpStatusCode.Created)
                    .AddCorsHeader();
            };
        }
    }
}
