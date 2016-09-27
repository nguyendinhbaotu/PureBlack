using System.Collections.Generic;

namespace PureBlack.Searching
{
    public interface IFilter
    {
        IEnumerable<string> ParameterNames { get; set; }

        string DisplayText { get; set; }
    }
}
