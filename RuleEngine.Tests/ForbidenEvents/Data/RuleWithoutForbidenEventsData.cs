using RuleEngine.Service;
using RuleEngine.Service.Models;

using System;
using System.Collections.Generic;

namespace RuleEngine.Tests.ForbidenEvents.Data
{
    public class RuleWithoutForbidenEventsData : IData
    {
        public List<LiveEvent> LiveEvents { get; set; }
        public List<Rule> Rules { get; set; }

        public RuleWithoutForbidenEventsData()
        {
            Rules = new List<Rule>()
            {
                new Rule()
                {
                    TurbineIds = new List<string>() { "1" , "3" , "5" },
                    TurbineAggregation = TurbineAggregation.All,
                    ForbidenEvents = new List<string>(),
                    RequiredEvents = new List<string>() { "2" },
                    Diagnosis = string.Empty
                }
            };

            LiveEvents = new List<LiveEvent>()
            {
                new LiveEvent()
                {
                    TurbineId = "3",
                    EventIds = new List<string>() {"10"},
                    Timestamp = DateTime.Now
                },
                new LiveEvent()
                {
                    TurbineId = "5",
                    EventIds = new List<string>() {"5"},
                    Timestamp = DateTime.Now
                }
            };
        }
    }
}
