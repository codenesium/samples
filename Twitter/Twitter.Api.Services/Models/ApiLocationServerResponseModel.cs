using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiLocationServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>958eb752dafcddfdab8f566bdcef1816</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/