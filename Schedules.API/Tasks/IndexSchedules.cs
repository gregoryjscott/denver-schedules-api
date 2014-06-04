﻿using Jagger;
using Nancy;

namespace Schedules.API
{
    public class IndexSchedules : JaggerTask
    {
        public override void Execute()
        {
            Out.Response = In.Module.Response.AsJson(new {
                Title = "City Holidays",
                Events = new [] {
                    new {
                        Desc = "New Years Day",
                        Day = "Wednesday",
                        StartDate = "01.01.2014"
                    },
                    new {
                        Desc = "Martin Luther King Day",
                        Day = "Monday",
                        StartDate = "01.20.2014"
                    },
                    new {
                        Desc = "President's Day",
                        Day = "Monday",
                        StartDate = "02.27.2014"
                    },
                    new {
                        Desc = "Cesar Chavez Day",
                        Day = "Monday",
                        StartDate = "03.31.2014"
                    },
                    new {
                        Desc = "Memorial Day",
                        Day = "Monday",
                        StartDate = "05.26.2014"
                    },
                    new {
                        Desc = "Independence Day",
                        Day = "Friday",
                        StartDate = "07.04.2014"
                    },
                    new {
                        Desc = "Labor Day",
                        Day = "Monday",
                        StartDate = "11.01.2014"
                    },
                    new {
                        Desc = "Thanksgiving Day",
                        Day = "Thursday",
                        StartDate = "11.27.2014"
                    },
                    new {
                        Desc = "Christmas Day",
                        Day = "Monday",
                        StartDate = "12.25.2014"
                    }
                }
            });
        }
    }
}