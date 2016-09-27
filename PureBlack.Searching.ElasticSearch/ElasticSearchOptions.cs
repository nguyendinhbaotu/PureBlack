using System.Collections.Generic;

namespace PureBlack.Searching.Elastic
{
    public class ElasticSearchOptions
    {
        public IEnumerable<string> Connections { get; set; }

        public string IndexName { get; set; }
    }
}