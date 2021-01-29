using RuleEngine.Service.Models;

using System;
using System.Collections.Generic;

namespace RuleEngine.Service
{
    public class Data : IData
    {
        public List<LiveEvent> LiveEvents { get; set; }
        public List<Rule> Rules { get; set; }

        public Data()
        {
            InitializeLiveEvents();
            InitializeRules();
        }

        // assuming there are six turbines (by IDs), and ten possible events
        // note: there is no given live event for second and sixth turbine
        private void InitializeLiveEvents()
        {
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
                },
                new LiveEvent()
                {
                    TurbineId = "3",
                    EventIds = new List<string>() {"5", "6"},
                    Timestamp = DateTime.Now
                },
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
                },
            };
        }

        // assuming six given rules
        private void InitializeRules()
        {
            Rules = new List<Rule>()
            {
                new Rule()
                {
                    TurbineIds = new List<string>() {"1", "3"},
                    TurbineAggregation = TurbineAggregation.All,
                    ForbidenEvents = new List<string>() {"5", "6"},
                    RequiredEvents = new List<string>() {"2"},
                    Diagnosis = string.Empty
                },
                new Rule()
                {
                    TurbineIds = new List<string>() {"3", "4", "6"},
                    TurbineAggregation = TurbineAggregation.All,
                    ForbidenEvents = new List<string>() {"2"},
                    RequiredEvents = new List<string>() {"7"},
                    Diagnosis = string.Empty
                },
                new Rule()
                {
                    TurbineIds = new List<string>() {"1", "4"},
                    TurbineAggregation = TurbineAggregation.Any,
                    ForbidenEvents = new List<string>() {"4"},
                    RequiredEvents = new List<string>() {"1"},
                    Diagnosis = string.Empty
                },
                new Rule()
                {
                    TurbineIds = new List<string>() {"4", "5"},
                    TurbineAggregation = TurbineAggregation.Any,
                    ForbidenEvents = new List<string>() {"5"},
                    RequiredEvents = new List<string>() {"6"},
                    Diagnosis = string.Empty
                },
                new Rule()
                {
                    TurbineIds = new List<string>() {"3", "4"},
                    TurbineAggregation = TurbineAggregation.Single,
                    ForbidenEvents = new List<string>() {"3"},
                    RequiredEvents = new List<string>() {"1"},
                    Diagnosis = string.Empty
                },
                new Rule()
                {
                    TurbineIds = new List<string>() {"2", "5"},
                    TurbineAggregation = TurbineAggregation.Single,
                    ForbidenEvents = new List<string>() {"8"},
                    RequiredEvents = new List<string>() {"2"},
                    Diagnosis = string.Empty
                }
            };
        }
    }
}
