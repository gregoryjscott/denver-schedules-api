using NUnit.Framework;

namespace Schedules.API.Tests
{
  [TestFixture]
  public class ThingThatUsesConfigTest
  {
    [Test]
    public void TestIt()
    {
      var something = ThingThatUsesConfig.GetConfigValue();
      Assert.That(something, Is.EqualTo("important"));
    }
  }
}

