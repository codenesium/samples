using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiLocationRequestModel : AbstractApiRequestModel
	{
		public ApiLocationRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int gpsLat,
			int gpsLong,
			string locationName)
		{
			this.GpsLat = gpsLat;
			this.GpsLong = gpsLong;
			this.LocationName = locationName;
		}

		[Required]
		[JsonProperty]
		public int GpsLat { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int GpsLong { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string LocationName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>1bdbff36e063bfd4d4d5c9665946e228</Hash>
</Codenesium>*/