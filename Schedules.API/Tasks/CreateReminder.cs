using Simpler;
using Schedules.API.Models;
using Nancy;
using Nancy.ModelBinding;

namespace Schedules.API
{
    public class CreateReminder : InOutTask<CreateReminder.Input, CreateReminder.Output>
    {
        public class Input
        {
            public JaggerModule Module { get; set; }
            public dynamic Parameters { get; set; }
        }

        public class Output
        {
            public dynamic Response { get; set; }
        }

        public override void Execute()
        {
            Reminder reminder = In.Module.Bind<Reminder>();
            Out.Response = In.Module.Response.AsJson(reminder, HttpStatusCode.Created);
        }
    }
}
