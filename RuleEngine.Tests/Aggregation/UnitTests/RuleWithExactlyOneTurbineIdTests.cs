using RuleEngine.Service;
using RuleEngine.Service.Models;
using RuleEngine.Service.Service;
using RuleEngine.Tests.Aggregation.Data;

using System.Linq;

using Xunit;
using Xunit.Abstractions;

namespace RuleEngine.Tests.Aggregation.UnitTests
{
    public class RuleWithExactlyOneTurbineIdTests
    {
        private readonly IImportManager _importManagerNoLiveEvents;
        private readonly IImportManager _importManagerNoRelatedLiveEvents;
        private readonly IImportManager _importManagerRelatedLiveEventsExist;

        private readonly IData _oneTurbineRuleNoLiveEvents;
        private readonly IData _oneTurbineRuleNoRelatedLiveEvents;
        private readonly IData _oneTurbineRuleRelatedLiveEventsExist;

        private readonly ITestOutputHelper _output;

        public RuleWithExactlyOneTurbineIdTests(ITestOutputHelper output)
        {
            _output = output;

            _oneTurbineRuleNoLiveEvents = new OneTurbineRuleNoLiveEvents();
            _oneTurbineRuleNoRelatedLiveEvents = new OneTurbineRuleNoRelatedLiveEvents();
            _oneTurbineRuleRelatedLiveEventsExist = new OneTurbineRuleRelatedLiveEventsExist();

            _importManagerNoLiveEvents = new ImportManager(_oneTurbineRuleNoLiveEvents);
            _importManagerNoRelatedLiveEvents = new ImportManager(_oneTurbineRuleNoRelatedLiveEvents);
            _importManagerRelatedLiveEventsExist = new ImportManager(_oneTurbineRuleRelatedLiveEventsExist);
        }

        [Fact]
        [Trait("Aggregation", "All")]
        public void AllAggregationShouldFailWhenNoLiveEvents()
        {
            Assert.False(_importManagerNoLiveEvents.IsTurbineAggregationSatisfied(_oneTurbineRuleNoLiveEvents.
                                                                                    Rules.
                                                                                    SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.All)));
        }

        [Fact]
        [Trait("Aggregation", "All")]
        public void AllAggregationShouldFailWhenNoRelatedLiveEvents()
        {
            Assert.False(_importManagerNoRelatedLiveEvents.IsTurbineAggregationSatisfied(_oneTurbineRuleNoRelatedLiveEvents.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.All)));
        }

        [Fact]
        [Trait("Aggregation", "All")]
        public void AllAggregationShouldPassWhenRelatedLiveEventsExists()
        {
            Assert.True(_importManagerRelatedLiveEventsExist.IsTurbineAggregationSatisfied(_oneTurbineRuleRelatedLiveEventsExist.
                                                                                                Rules.
                                                                                                SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.All)));
        }

        [Fact]
        [Trait("Aggregation", "Any")]
        public void AnyAggregationShouldFailWhenNoLiveEvents()
        {
            Assert.False(_importManagerNoLiveEvents.IsTurbineAggregationSatisfied(_oneTurbineRuleNoLiveEvents.
                                                                                    Rules.
                                                                                    SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Any)));
        }

        [Fact]
        [Trait("Aggregation", "Any")]
        public void AnyAggregationShouldFailWhenNoRelatedLiveEvents()
        {
            Assert.False(_importManagerNoRelatedLiveEvents.IsTurbineAggregationSatisfied(_oneTurbineRuleNoRelatedLiveEvents.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Any)));
        }

        [Fact]
        [Trait("Aggregation", "Any")]
        public void AnyAggregationShouldPassWhenRelatedLiveEventsExists()
        {
            Assert.True(_importManagerRelatedLiveEventsExist.IsTurbineAggregationSatisfied(_oneTurbineRuleRelatedLiveEventsExist.
                                                                                                Rules.
                                                                                                SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Any)));
        }

        [Fact]
        [Trait("Aggregation", "Single")]
        public void SingleAggregationShouldFailWhenNoLiveEvents()
        {
            Assert.False(_importManagerNoLiveEvents.IsTurbineAggregationSatisfied(_oneTurbineRuleNoLiveEvents.
                                                                                    Rules.
                                                                                    SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Single)));
        }

        [Fact]
        [Trait("Aggregation", "Single")]
        public void SingleAggregationShouldFailWhenNoRelatedLiveEvents()
        {
            Assert.False(_importManagerNoRelatedLiveEvents.IsTurbineAggregationSatisfied(_oneTurbineRuleNoRelatedLiveEvents.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Single)));
        }

        [Fact]
        [Trait("Aggregation", "Single")]
        public void SingleAggregationShouldPassWhenRelatedLiveEventsExists()
        {
            Assert.True(_importManagerRelatedLiveEventsExist.IsTurbineAggregationSatisfied(_oneTurbineRuleRelatedLiveEventsExist.
                                                                                                Rules.
                                                                                                SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Single)));
        }
    }
}
