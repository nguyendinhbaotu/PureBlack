using System.Collections.Generic;

namespace PureBlack.EntityMarkers
{
    public interface IDetailsWiseEntity<TEntityDetail>
        where TEntityDetail : class
    {
        ICollection<TEntityDetail> Details { get; set; }
    }
}
