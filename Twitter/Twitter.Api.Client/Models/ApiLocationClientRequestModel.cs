using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiLocationClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiLocationClientRequestModel()
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

		[JsonProperty]
		public int GpsLat { get; private set; } = default(int);

		[JsonProperty]
		public int GpsLong { get; private set; } = default(int);

		[JsonProperty]
		public string LocationName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>b2f6bf24026c0b875594a7cd56898feb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/