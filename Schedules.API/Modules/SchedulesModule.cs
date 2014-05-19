using Nancy;

public class SchedulesModule : NancyModule
{
	public SchedulesModule()
	{
		Get ["/schedules"] = _ => {
			var holidays = new {
				Title = "City Holidays",
			};

            return Response.AsJson(holidays).WithHeader("Access-Control-Allow-Origin", "*");
		};
	}
}