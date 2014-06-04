using Jagger;
using System.IO;

public class SchedulesModule : JaggerModule
{
    public SchedulesModule() : base(File.ReadAllText("Resources/schedule.json")) {}
}
