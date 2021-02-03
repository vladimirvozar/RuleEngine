using RuleEngine.Service;
using RuleEngine.Service.Service;
using RuleEngine.Tests.ForbidenEvents.Data;

using System.Linq;

using Xunit;
using Xunit.Abstractions;

namespace RuleEngine.Tests.ForbidenEvents.UnitTests
{
    public class RuleWithForbidenEventsTests
    {
        private readonly IImportManager _importManagerWithForbidenEventsAndNoLiveEvents;
        private readonly IImportManager _importManagerWithForbidenEventsAndNoRelatedLiveEvents;
        private readonly IImportManager _importManagerWithForbidenEventsWithRelatedLiveEventsNoForbiden;
        private readonly IImportManager _importManagerWithForbidenEventsWithRelatedLiveEventsWithForbiden;

        private readonly IData _ruleWithForbidenEventsAndNoLiveEvents;
        private readonly IData _ruleWithForbidenEventsAndNoRelatedLiveEvents;
        private readonly IData _ruleWithForbidenEventsWithRelatedLiveEventsNoForbiden;
        private readonly IData _ruleWithForbidenEventsWithRelatedLiveEventsWithForbiden;

        private readonly ITestOutputHelper _output;

        public RuleWithForbidenEventsTests(ITestOutputHelper output)
        {
            _output = output;

            _ruleWithForbidenEventsAndNoLiveEvents = new RuleWithForbidenEventsAndNoLiveEventsData();
            _ruleWithForbidenEventsAndNoRelatedLiveEvents = new RuleWithForbidenEventsAndNoRelatedLiveEventsData();
            _ruleWithForbidenEventsWithRelatedLiveEventsNoForbiden = new RuleWithForbidenEventsWithRelatedLiveEventsNoForbidenData();
            _ruleWithForbidenEventsWithRelatedLiveEventsWithForbiden = new RuleWithForbidenEventsWithRelatedLiveEventsWithForbidenData();


            _importManagerWithForbidenEventsAndNoLiveEvents = new ImportManager(_ruleWithForbidenEventsAndNoLiveEvents);
            _importManagerWithForbidenEventsAndNoRelatedLiveEvents = new ImportManager(_ruleWithForbidenEventsAndNoRelatedLiveEvents);
            _importManagerWithForbidenEventsWithRelatedLiveEventsNoForbiden = new ImportManager(_ruleWithForbidenEventsWithRelatedLiveEventsNoForbiden);
            _importManagerWithForbidenEventsWithRelatedLiveEventsWithForbiden = new ImportManager(_ruleWithForbidenEventsWithRelatedLiveEventsWithForbiden);
        }

        [Fact]
        [Trait("ForbidenEvents", "NotEmpty")]
        public void ForbidenEventsShouldPassWhenNoLiveEvents()
        {
            Assert.True(_importManagerWithForbidenEventsAndNoLiveEvents.AreForbidenEventsSatisfied(_ruleWithForbidenEventsAndNoLiveEvents.
                                                                                    Rules.
                                                                                    SingleOrDefault()));
        }

        [Fact]
        [Trait("ForbidenEvents", "NotEmpty")]
        public void ForbidenEventsShouldPassWhenNoRelatedLiveEvents()
        {
            Assert.True(_importManagerWithForbidenEventsAndNoRelatedLiveEvents.AreForbidenEventsSatisfied(_ruleWithForbidenEventsAndNoRelatedLiveEvents.
                                                                                    Rules.
                                                                                    SingleOrDefault()));
        }

        [Fact]
        [Trait("ForbidenEvents", "NotEmpty")]
        public void ForbidenEventsShouldPassWhenRelatedLiveEventsExistAndNoForbiden()
        {
            Assert.True(_importManagerWithForbidenEventsWithRelatedLiveEventsNoForbiden.AreForbidenEventsSatisfied(_ruleWithForbidenEventsWithRelatedLiveEventsNoForbiden.
                                                                                    Rules.
                                                                                    SingleOrDefault()));
        }

        [Fact]
        [Trait("ForbidenEvents", "NotEmpty")]
        public void ForbidenEventsShouldFailWhenRelatedLiveEventsExistAndForbiden()
        {
            Assert.False(_importManagerWithForbidenEventsWithRelatedLiveEventsWithForbiden.AreForbidenEventsSatisfied(_ruleWithForbidenEventsWithRelatedLiveEventsWithForbiden.
                                                                                    Rules.
                                                                                    SingleOrDefault()));
        }
    }
}
