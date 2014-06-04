using Jagger;
using System.IO;

public class SchedulesModule : JaggerModule
{
    public SchedulesModule() : base(apiDeclaration: File.ReadAllText("Docs/schedules.json")) {}
}
