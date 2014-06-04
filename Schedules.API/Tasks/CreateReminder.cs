using Schedules.API.Models;
using Nancy;
using Nancy.ModelBinding;

namespace Schedules.API
{

    public class CreateReminder : JaggerTask
    {
        public override void Execute()
        {
            Reminder reminder = In.Module.Bind<Reminder>();
            Out.Response = In.Module.Response.AsJson(reminder, HttpStatusCode.Created);
        }
    }
}
