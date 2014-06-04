using System.IO;
using Jagger;

public class RemindersModule : JaggerModule
{
    public RemindersModule() : base(apiDeclaration: File.ReadAllText("Docs/reminders.json")) {}
}
