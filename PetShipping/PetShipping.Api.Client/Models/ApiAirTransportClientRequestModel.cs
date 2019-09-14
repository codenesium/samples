using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiAirTransportClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiAirTransportClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int airlineId,
			string flightNumber,
			int handlerId,
			DateTime landDate,
			int pipelineStepId,
			DateTime takeoffDate)
		{
			this.AirlineId = airlineId;
			this.FlightNumber = flightNumber;
			this.HandlerId = handlerId;
			this.LandDate = landDate;
			this.PipelineStepId = pipelineStepId;
			this.TakeoffDate = takeoffDate;
		}

		[JsonProperty]
		public int AirlineId { get; private set; } = default(int);

		[JsonProperty]
		public string FlightNumber { get; private set; } = default(string);

		[JsonProperty]
		public int HandlerId { get; private set; }

		[JsonProperty]
		public DateTime LandDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int PipelineStepId { get; private set; } = default(int);

		[JsonProperty]
		public DateTime TakeoffDate { get; private set; } = SqlDateTime.MinValue.Value;
	}
}

/*<Codenesium>
    <Hash>c85919a5565b52bf6eb53f5eb6ae34a8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/