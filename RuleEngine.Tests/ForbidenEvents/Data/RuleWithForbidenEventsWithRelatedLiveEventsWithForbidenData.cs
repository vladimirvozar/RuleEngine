using RuleEngine.Service;
using RuleEngine.Service.Models;

using System;
using System.Collections.Generic;

namespace RuleEngine.Tests.ForbidenEvents.Data
{
    public class RuleWithForbidenEventsWithRelatedLiveEventsWithForbidenData : IData
    {
        public List<LiveEvent> LiveEvents { get; set; }
        public List<Rule> Rules { get; set; }

        public RuleWithForbidenEventsWithRelatedLiveEventsWithForbidenData()
        {
            Rules = new List<Rule>()
            {
                new Rule()
                {
                    TurbineIds = new List<string>() { "1" , "3" , "5" },
                    TurbineAggregation = TurbineAggregation.All,
                    ForbidenEvents = new List<string>() { "2" , "4" , "7" , "8"},
                    RequiredEvents = new List<string>(),
                    Diagnosis = string.Empty
                }
            };

            LiveEvents = new List<LiveEvent>()
            {
                new LiveEvent()
                {
                    TurbineId = "1",
                    EventIds = new List<string>() {"7"},
                    Timestamp = DateTime.Now
                },
                new LiveEvent()
                {
                    TurbineId = "1",
                    EventIds = new List<string>() {"8"},
                    Timestamp = DateTime.Now
                }
            };
        }
    }
}
