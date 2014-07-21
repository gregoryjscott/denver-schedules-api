using System.Configuration;

namespace Schedules.API
{
  public class ThingThatUsesConfig
  {
    public static string GetConfigValue()
    {
      return ConfigurationManager.AppSettings["something"];
    }
  }
}

