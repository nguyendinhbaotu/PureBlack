using System;

namespace PureBlack.EntityMarkers
{
    public interface ITimeWiseEntity
    {
        DateTime DataCreateDate { get; set; }

        DateTime DataLastModifyDate { get; set; }
    }
}
