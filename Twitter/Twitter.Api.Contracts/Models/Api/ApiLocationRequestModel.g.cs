using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
    <Hash>b35835a529e9ccca1bfd0b2e2362df1f</Hash>
</Codenesium>*/