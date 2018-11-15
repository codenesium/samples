using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiLocationClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int locationId,
			int gpsLat,
			int gpsLong,
			string locationName)
		{
			this.LocationId = locationId;
			this.GpsLat = gpsLat;
			this.GpsLong = gpsLong;
			this.LocationName = locationName;
		}

		[JsonProperty]
		public int GpsLat { get; private set; }

		[JsonProperty]
		public int GpsLong { get; private set; }

		[JsonProperty]
		public int LocationId { get; private set; }

		[JsonProperty]
		public string LocationName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>aac170da6b726249ecbaef79e207a043</Hash>
</Codenesium>*/