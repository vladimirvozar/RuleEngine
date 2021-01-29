using RuleEngine.Service.Models;

using System.Collections.Generic;

namespace RuleEngine.Service
{
    public interface IData
    {
        List<LiveEvent> LiveEvents { get; set; }
        List<Rule> Rules { get; set; }
    }
}
