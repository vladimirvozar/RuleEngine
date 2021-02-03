using RuleEngine.Service;
using RuleEngine.Service.Models;

using System;
using System.Collections.Generic;

namespace RuleEngine.Tests.Aggregation.Data
{
    public class MultiTurbineRuleWithLiveEventsForSomeTurbines : IData
    {
        public List<LiveEvent> LiveEvents { get; set; }
        public List<Rule> Rules { get; set; }

        public MultiTurbineRuleWithLiveEventsForSomeTurbines()
        {
            Rules = new List<Rule>()
            {
                new Rule()
                {
                    TurbineIds = new List<string>() { "1" , "3" , "5" },
                    TurbineAggregation = TurbineAggregation.All,
                    ForbidenEvents = new List<string>(),
                    RequiredEvents = new List<string>(),
                    Diagnosis = string.Empty
                },
                new Rule()
                {
                    TurbineIds = new List<string>() { "1" , "3" , "5" },
                    TurbineAggregation = TurbineAggregation.Any,
                    ForbidenEvents = new List<string>(),
                    RequiredEvents = new List<string>(),
                    Diagnosis = string.Empty
                },
                new Rule()
                {
                    TurbineIds = new List<string>() { "1" , "3" , "5" },
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
