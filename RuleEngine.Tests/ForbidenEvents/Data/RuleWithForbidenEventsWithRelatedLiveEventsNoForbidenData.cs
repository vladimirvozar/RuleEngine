using RuleEngine.Service;
using RuleEngine.Service.Models;

using System;
using System.Collections.Generic;

namespace RuleEngine.Tests.ForbidenEvents.Data
{
    public class RuleWithForbidenEventsWithRelatedLiveEventsNoForbidenData : IData
    {
        public List<LiveEvent> LiveEvents { get; set; }
        public List<Rule> Rules { get; set; }

        public RuleWithForbidenEventsWithRelatedLiveEventsNoForbidenData()
        {
            Rules = new List<Rule>()
            {
                new Rule()
                {
                    TurbineIds = new List<string>() { "1" , "3" , "5" },
                    TurbineAggregation = TurbineAggregation.All,
                    ForbidenEvents = new List<string>() { "2" , "4" },
                    RequiredEvents = new List<string>(),
                    Diagnosis = string.Empty
                }
            };

            LiveEvents = new List<LiveEvent>()
            {
                new LiveEvent()
                {
                    TurbineId = "1",
                    EventIds = new List<string>() {"10"},
                    Timestamp = DateTime.Now
                },
                new LiveEvent()
                {
                    TurbineId = "1",
                    EventIds = new List<string>() {"9"},
                    Timestamp = DateTime.Now
                }
            };
        }
    }
}
