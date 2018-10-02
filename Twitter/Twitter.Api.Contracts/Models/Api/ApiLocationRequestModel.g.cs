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
		public int GpsLat { get; private set; }

		[Required]
		[JsonProperty]
		public int GpsLong { get; private set; }

		[Required]
		[JsonProperty]
		public string LocationName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>21ad18243453517c64a9cf5b54e0319d</Hash>
</Codenesium>*/