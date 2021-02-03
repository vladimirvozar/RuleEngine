using RuleEngine.Service;
using RuleEngine.Service.Service;
using RuleEngine.Tests.ForbidenEvents.Data;

using System.Linq;

using Xunit;
using Xunit.Abstractions;

namespace RuleEngine.Tests.ForbidenEvents.UnitTests
{
    public class RuleWithoutForbidenEventsTests
    {
        private readonly IImportManager _importManagerNoForbidenEvents;

        private readonly IData _ruleWithoutForbidenEventsData;

        private readonly ITestOutputHelper _output;

        public RuleWithoutForbidenEventsTests(ITestOutputHelper output)
        {
            _output = output;

            _ruleWithoutForbidenEventsData = new RuleWithoutForbidenEventsData();

            _importManagerNoForbidenEvents = new ImportManager(_ruleWithoutForbidenEventsData);
        }

        [Fact]
        [Trait("ForbidenEvents", "Empty")]
        public void ForbidenEventsShouldPassWhenNoForbidenEventsInTheRule()
        {
            Assert.True(_importManagerNoForbidenEvents.AreForbidenEventsSatisfied(_ruleWithoutForbidenEventsData.
                                                                                    Rules.
                                                                                    SingleOrDefault(rule => !rule.ForbidenEvents.Any())));
        }


    }
}
