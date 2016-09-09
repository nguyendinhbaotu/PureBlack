using System;

namespace PureBlack.EntityMarkers
{
    public interface IIdWiseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
