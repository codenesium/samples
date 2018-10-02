using Codenesium.DataConversionExtensions;
using System;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractBOLocation : AbstractBusinessObject
	{
		public AbstractBOLocation()
			: base()
		{
		}

		public virtual void SetProperties(int locationId,
		                                  int gpsLat,
		                                  int gpsLong,
		                                  string locationName)
		{
			this.GpsLat = gpsLat;
			this.GpsLong = gpsLong;
			this.LocationId = locationId;
			this.LocationName = locationName;
		}

		public int GpsLat { get; private set; }

		public int GpsLong { get; private set; }

		public int LocationId { get; private set; }

		public string LocationName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>38212e5c8f708fc543bfa26e1d982b68</Hash>
</Codenesium>*/