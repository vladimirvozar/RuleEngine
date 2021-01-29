using MoreLinq;

using RuleEngine.Service.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngine.Service.Service
{
    public class ImportManager : IImportManager
    {
        private readonly IData _givenData;
        private readonly IEnumerable<string> _distinctTurbineIDs;

        public ImportManager(IData givenData)
        {
            _givenData = givenData ?? throw new ArgumentNullException(nameof(givenData));

            _distinctTurbineIDs = _givenData.LiveEvents
                                            .DistinctBy(le => le.TurbineId)
                                            .Select(le => le.TurbineId);
        }

        public void Run()
        {
            Console.WriteLine("\nImporting data: " + DateTime.Now.ToString() + "\n");
            _givenData.Rules.ForEach(SetRuleDiagnosis);
        }

        private void SetRuleDiagnosis(Rule rule)
        {
            // check TurbineAggregation
            if (!IsTurbineAggregationSatisfied(rule))
            {
                rule.Diagnosis = Constants.TurbineAggregationNotSatisfied;
            }

            // check ForbidenEvents
            if (!AreForbidenEventsSatisfied(rule))
            {
                rule.Diagnosis += Constants.ForbidenEventsNotSatisfied;
            }

            // check RequiredEvents
            if (!AreRequiredEventsSatisfied(rule))
            {
                rule.Diagnosis += Constants.RequiredEventsNotSatisfied;
            }

            if(string.IsNullOrEmpty(rule.Diagnosis))
            {
                rule.Diagnosis = Constants.Satisfied;
            }

            PrintRuleDetails(rule);
        }

        private bool IsTurbineAggregationSatisfied(Rule rule)
        {
            bool turbineAggregationSatisfied = false;

            switch (rule.TurbineAggregation)
            {
                case TurbineAggregation.All:
                    turbineAggregationSatisfied = rule.TurbineIds.All(value => _distinctTurbineIDs.Contains(value));
                    break;
                case TurbineAggregation.Any:
                    turbineAggregationSatisfied = rule.TurbineIds.Any(value => _distinctTurbineIDs.Contains(value));
                    break;
                case TurbineAggregation.Single:
                    turbineAggregationSatisfied = rule.TurbineIds.Intersect(_distinctTurbineIDs).Count() == 1;
                    break;
                default:
                    break;
            }

            return turbineAggregationSatisfied;
        }

        private bool AreForbidenEventsSatisfied(Rule rule)
        {
            bool existsInForbiden = false;

            foreach (var liveEvent in _givenData.LiveEvents)
            {
                if(rule.TurbineIds.Contains(liveEvent.TurbineId))  // compare only rule related live events
                {
                    if(rule.ForbidenEvents.Any(value => liveEvent.EventIds.Contains(value)))
                    {
                        existsInForbiden = true;
                    }
                }
            }

            return !existsInForbiden;
        }

        private bool AreRequiredEventsSatisfied(Rule rule)
        {
            foreach (var liveEvent in _givenData.LiveEvents)
            {
                if (rule.TurbineIds.Contains(liveEvent.TurbineId))  // compare only rule related live events
                {
                    if (rule.RequiredEvents.Any(value => liveEvent.EventIds.Contains(value)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
        private void PrintRuleDetails(Rule rule)
        {
            Console.WriteLine("Rule details:");
            Console.WriteLine("TurbineIds: " + string.Join(",", rule.TurbineIds));
            Console.WriteLine("TurbineAggregation: " + rule.TurbineAggregation);
            Console.WriteLine("ForbidenEvents: " + string.Join(",", rule.ForbidenEvents));
            Console.WriteLine("RequiredEvents: " + string.Join(",", rule.RequiredEvents));
            Console.WriteLine("Diagnosis: " + rule.Diagnosis);
            Console.WriteLine("-------------------------");
        }
    }
}
