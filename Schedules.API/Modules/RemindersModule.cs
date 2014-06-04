using System.IO;

public class RemindersModule : JaggerModule
{
    public RemindersModule() : base(File.ReadAllText("Docs/reminders.json")) {}
}
