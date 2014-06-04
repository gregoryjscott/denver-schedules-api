using System.IO;
using Jagger;

public class RemindersModule : JaggerModule
{
    public RemindersModule() : base(File.ReadAllText("Resources/reminder.json")) {}
}
