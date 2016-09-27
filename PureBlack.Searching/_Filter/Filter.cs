using System.Collections.Generic;

namespace PureBlack.Searching
{
    public abstract class Filter<TOption> : IFilter
        where TOption : IFilterOption
    {
        public IEnumerable<string> ParameterNames { get; set; }

        public string DisplayText { get; set; }

        public ICollection<TOption> Options { get; set; }
    }
}