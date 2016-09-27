using Nest;

namespace PureBlack.Searching.Elastic
{
    public interface IElasticFilter
    {
        void BuildOptions(BucketAggregate bucket);
    }
}
