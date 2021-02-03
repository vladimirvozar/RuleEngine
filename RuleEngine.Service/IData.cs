using RuleEngine.Service.Models;

using System.Collections.Generic;

namespace RuleEngine.Service
{
    public interface IData
    {
        public List<LiveEvent> LiveEvents { get; set; }
        public List<Rule> Rules { get; set; }
    }
}
