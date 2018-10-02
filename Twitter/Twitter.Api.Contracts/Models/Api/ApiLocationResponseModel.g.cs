using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiLocationResponseModel : AbstractApiResponseModel
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
    <Hash>d1fa985fe183897e3a6dfc8310348d7e</Hash>
</Codenesium>*/