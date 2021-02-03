using RuleEngine.Service.Models;

namespace RuleEngine.Service.Service
{
    public interface IImportManager
    {
        void Run();

        public bool IsTurbineAggregationSatisfied(Rule rule);
        public bool AreForbidenEventsSatisfied(Rule rule);
        public bool AreRequiredEventsSatisfied(Rule rule);
    }
}
