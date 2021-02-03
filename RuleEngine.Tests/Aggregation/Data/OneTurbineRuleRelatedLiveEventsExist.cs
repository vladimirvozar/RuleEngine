using RuleEngine.Service;
using RuleEngine.Service.Models;

using System;
using System.Collections.Generic;

namespace RuleEngine.Tests.Aggregation.Data
{
    public class OneTurbineRuleRelatedLiveEventsExist : IData
    {
        public List<LiveEvent> LiveEvents { get; set; }
        public List<Rule> Rules { get; set; }

        public OneTurbineRuleRelatedLiveEventsExist()
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
                    TurbineId = "1",
                    EventIds = new List<string>() {"1", "2", "3"},
                    Timestamp = DateTime.Now
                },
                new LiveEvent()
                {
                    TurbineId = "1",
                    EventIds = new List<string>() {"8", "9"},
                    Timestamp = DateTime.Now
                },
                new LiveEvent()
                {
                    TurbineId = "3",
                    EventIds = new List<string>() {"1"},
                    Timestamp = DateTime.Now
                }
            };
        }
    }
}
