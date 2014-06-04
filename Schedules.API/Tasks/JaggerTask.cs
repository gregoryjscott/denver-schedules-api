using Simpler;

namespace Schedules.API
{
    public abstract class JaggerTask : InOutTask<JaggerTask.Input, JaggerTask.Output>
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
    }
}
