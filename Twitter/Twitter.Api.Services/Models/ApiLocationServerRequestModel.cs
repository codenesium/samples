using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiLocationServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiLocationServerRequestModel()
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
    <Hash>7ff5d484847a40952a3a6a2fb4da8dda</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/