using RuleEngine.Service;
using RuleEngine.Service.Models;
using RuleEngine.Service.Service;
using RuleEngine.Tests.Aggregation.Data;

using System.Linq;

using Xunit;
using Xunit.Abstractions;

namespace RuleEngine.Tests.Aggregation.UnitTests
{
    public class RuleWithMultipleTurbineIdsTests
    {
        private readonly IImportManager _importManagerNoLiveEvents;
        private readonly IImportManager _importManagerNoRelatedLiveEvents;
        private readonly IImportManager _importManagerWithLiveEventsForEveryTurbine;
        private readonly IImportManager _importManagerWithLiveEventsForOneTurbine;
        private readonly IImportManager _importManagerWithLiveEventsForSomeTurbines;

        private readonly IData _multiTurbineRuleNoLiveEvents;
        private readonly IData _multiTurbineRuleNoRelatedLiveEvents;
        private readonly IData _multiTurbineRuleWithLiveEventsForEveryTurbine;
        private readonly IData _multiTurbineRuleWithLiveEventsForOneTurbine;
        private readonly IData _multiTurbineRuleWithLiveEventsForSomeTurbines;

        private readonly ITestOutputHelper _output;

        public RuleWithMultipleTurbineIdsTests(ITestOutputHelper output)
        {
            _output = output;

            _multiTurbineRuleNoLiveEvents = new MultiTurbineRuleNoLiveEvents();
            _multiTurbineRuleNoRelatedLiveEvents = new MultiTurbineRuleNoRelatedLiveEvents();
            _multiTurbineRuleWithLiveEventsForEveryTurbine = new MultiTurbineRuleWithLiveEventsForEveryTurbine();
            _multiTurbineRuleWithLiveEventsForOneTurbine = new MultiTurbineRuleWithLiveEventsForOneTurbine();
            _multiTurbineRuleWithLiveEventsForSomeTurbines = new MultiTurbineRuleWithLiveEventsForSomeTurbines();


            _importManagerNoLiveEvents = new ImportManager(_multiTurbineRuleNoLiveEvents);
            _importManagerNoRelatedLiveEvents = new ImportManager(_multiTurbineRuleNoRelatedLiveEvents);
            _importManagerWithLiveEventsForEveryTurbine = new ImportManager(_multiTurbineRuleWithLiveEventsForEveryTurbine);
            _importManagerWithLiveEventsForOneTurbine = new ImportManager(_multiTurbineRuleWithLiveEventsForOneTurbine);
            _importManagerWithLiveEventsForSomeTurbines = new ImportManager(_multiTurbineRuleWithLiveEventsForSomeTurbines);
        }

        #region AllAggregation

        [Fact]
        [Trait("Aggregation", "All")]
        public void AllAggregationShouldFailWhenNoLiveEvents()
        {
            Assert.False(_importManagerNoLiveEvents.IsTurbineAggregationSatisfied(_multiTurbineRuleNoLiveEvents.
                                                                                    Rules.
                                                                                    SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.All)));
        }

        [Fact]
        [Trait("Aggregation", "All")]
        public void AllAggregationShouldFailWhenNoRelatedLiveEvents()
        {
            Assert.False(_importManagerNoRelatedLiveEvents.IsTurbineAggregationSatisfied(_multiTurbineRuleNoRelatedLiveEvents.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.All)));
        }

        [Fact]
        [Trait("Aggregation", "All")]
        public void AllAggregationShouldPassWhenExistLiveEventForEveryTurbine()
        {
            Assert.True(_importManagerWithLiveEventsForEveryTurbine.IsTurbineAggregationSatisfied(_multiTurbineRuleWithLiveEventsForEveryTurbine.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.All)));
        }

        [Fact]
        [Trait("Aggregation", "All")]
        public void AllAggregationShouldFailWhenExistLiveEventForExactlyOneTurbine()
        {
            Assert.False(_importManagerWithLiveEventsForOneTurbine.IsTurbineAggregationSatisfied(_multiTurbineRuleWithLiveEventsForOneTurbine.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.All)));
        }

        [Fact]
        [Trait("Aggregation", "All")]
        public void AllAggregationShouldFailWhenExistLiveEventForMoreThanOneTurbine()
        {
            Assert.False(_importManagerWithLiveEventsForSomeTurbines.IsTurbineAggregationSatisfied(_multiTurbineRuleWithLiveEventsForSomeTurbines.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.All)));
        }

        #endregion AllAggregation

        #region AnyAggregation
        [Fact]
        [Trait("Aggregation", "Any")]
        public void AnyAggregationShouldFailWhenNoLiveEvents()
        {
            Assert.False(_importManagerNoLiveEvents.IsTurbineAggregationSatisfied(_multiTurbineRuleNoLiveEvents.
                                                                                    Rules.
                                                                                    SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Any)));
        }

        [Fact]
        [Trait("Aggregation", "Any")]
        public void AnyAggregationShouldFailWhenNoRelatedLiveEvents()
        {
            Assert.False(_importManagerNoRelatedLiveEvents.IsTurbineAggregationSatisfied(_multiTurbineRuleNoRelatedLiveEvents.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Any)));
        }

        [Fact]
        [Trait("Aggregation", "Any")]
        public void AnyAggregationShouldPassWhenExistLiveEventForEveryTurbine()
        {
            Assert.True(_importManagerWithLiveEventsForEveryTurbine.IsTurbineAggregationSatisfied(_multiTurbineRuleWithLiveEventsForEveryTurbine.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Any)));
        }

        [Fact]
        [Trait("Aggregation", "Any")]
        public void AnyAggregationShouldPassWhenExistLiveEventForExactlyOneTurbine()
        {
            Assert.True(_importManagerWithLiveEventsForOneTurbine.IsTurbineAggregationSatisfied(_multiTurbineRuleWithLiveEventsForOneTurbine.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Any)));
        }

        [Fact]
        [Trait("Aggregation", "Any")]
        public void AnyAggregationShouldPassWhenExistLiveEventForMoreThanOneTurbine()
        {
            Assert.True(_importManagerWithLiveEventsForSomeTurbines.IsTurbineAggregationSatisfied(_multiTurbineRuleWithLiveEventsForSomeTurbines.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Any)));
        }
        #endregion AnyAggregation

        #region SingleAggregation
        [Fact]
        [Trait("Aggregation", "Single")]
        public void SingleAggregationShouldFailWhenNoLiveEvents()
        {
            Assert.False(_importManagerNoLiveEvents.IsTurbineAggregationSatisfied(_multiTurbineRuleNoLiveEvents.
                                                                                    Rules.
                                                                                    SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Single)));
        }

        [Fact]
        [Trait("Aggregation", "Single")]
        public void SingleAggregationShouldFailWhenNoRelatedLiveEvents()
        {
            Assert.False(_importManagerNoRelatedLiveEvents.IsTurbineAggregationSatisfied(_multiTurbineRuleNoRelatedLiveEvents.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Single)));
        }

        [Fact]
        [Trait("Aggregation", "Single")]
        public void SingleAggregationShouldFailWhenExistLiveEventForEveryTurbine()
        {
            Assert.False(_importManagerWithLiveEventsForEveryTurbine.IsTurbineAggregationSatisfied(_multiTurbineRuleWithLiveEventsForEveryTurbine.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Single)));
        }

        [Fact]
        [Trait("Aggregation", "Single")]
        public void SingleAggregationShouldPassWhenExistLiveEventForExactlyOneTurbine()
        {
            Assert.True(_importManagerWithLiveEventsForOneTurbine.IsTurbineAggregationSatisfied(_multiTurbineRuleWithLiveEventsForOneTurbine.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Single)));
        }

        [Fact]
        [Trait("Aggregation", "Single")]
        public void SingleAggregationShouldFailWhenExistLiveEventForMoreThanOneTurbine()
        {
            Assert.False(_importManagerWithLiveEventsForSomeTurbines.IsTurbineAggregationSatisfied(_multiTurbineRuleWithLiveEventsForSomeTurbines.
                                                                                            Rules.
                                                                                            SingleOrDefault(rule => rule.TurbineAggregation == TurbineAggregation.Single)));
        }
        #endregion
    }
}
