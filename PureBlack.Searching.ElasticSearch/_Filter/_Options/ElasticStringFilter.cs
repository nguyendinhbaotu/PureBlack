﻿using System.Collections.Generic;
using System.Linq;
using Nest;

namespace PureBlack.Searching.Elastic
{
    public class ElasticStringFilter : Filter<StringFilterOption>, IElasticFilter
    {
        public void BuildOptions(BucketAggregate bucket)
        {
            Options = new List<StringFilterOption>();
            foreach (KeyedBucket item in bucket.Items.Where(x => ((KeyedBucket)x).DocCount > 0))
            {
                var option = new StringFilterOption {
                    Value = item.Key,
                    EntityCount = item.DocCount.Value
                };

                Options.Add(option);
            }
        }
    }
}
