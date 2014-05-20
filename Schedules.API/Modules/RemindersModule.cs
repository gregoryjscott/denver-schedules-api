using Nancy;
using Nancy.ModelBinding;
using Schedules.API.Models;

namespace Schedules.API
{
    public class RemindersModule : NancyModule
    {
    	public RemindersModule()
    	{
            Get["/reminders"] = _ => Response.AsJson(new[] {
                new Reminder {
                    Email = "whatever"
                }
            }).AddCorsHeader();

            Post["/reminders"] = _ => { 
                Reminder reminder = this.Bind<Reminder>();
                return Response.AsJson(reminder, HttpStatusCode.Created)
                    .AddCorsHeader();
            };
    	}
    }
}
