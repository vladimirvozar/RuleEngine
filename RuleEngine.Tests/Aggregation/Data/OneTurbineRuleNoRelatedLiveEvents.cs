using RuleEngine.Service;
using RuleEngine.Service.Models;

using System;
using System.Collections.Generic;

namespace RuleEngine.Tests.Aggregation.Data
{
    public class OneTurbineRuleNoRelatedLiveEvents : IData
    {
        public List<LiveEvent> LiveEvents { get; set; }
        public List<Rule> Rules { get; set; }

        public OneTurbineRuleNoRelatedLiveEvents()
        {
            Rules = new List<Rule>()
            {
                new Rule()
                {
                    TurbineIds = new List<string>() { "1" },
                    TurbineAggregation = TurbineAggregation.All,
                    ForbidenEvents = new List<string>(),
                    RequiredEvents = new List<string>(),
                    Diagnosis = string.Empty
                },
                new Rule()
                {
                    TurbineIds = new List<string>() { "1" },
                    TurbineAggregation = TurbineAggregation.Any,
                    ForbidenEvents = new List<string>(),
                    RequiredEvents = new List<string>(),
                    Diagnosis = string.Empty
                },
                new Rule()
                {
                    TurbineIds = new List<string>() { "1" },
                    TurbineAggregation = TurbineAggregation.Single,
                    ForbidenEvents = new List<string>(),
                    RequiredEvents = new List<string>(),
                    Diagnosis = string.Empty
                }
            };

            LiveEvents = new List<LiveEvent>()
            {
                new LiveEvent()
                {
                    TurbineId = "3",
                    EventIds = new List<string>() {"2", "7", "8", "9", "10"},
                    Timestamp = DateTime.Now
                },
                new LiveEvent()
                {
                    TurbineId = "4",
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
