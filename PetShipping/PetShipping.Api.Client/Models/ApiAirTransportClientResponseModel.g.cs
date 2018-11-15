using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiAirTransportClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int airlineId,
			string flightNumber,
			int handlerId,
			int id,
			DateTime landDate,
			int pipelineStepId,
			DateTime takeoffDate)
		{
			this.AirlineId = airlineId;
			this.FlightNumber = flightNumber;
			this.HandlerId = handlerId;
			this.Id = id;
			this.LandDate = landDate;
			this.PipelineStepId = pipelineStepId;
			this.TakeoffDate = takeoffDate;

			this.HandlerIdEntity = nameof(ApiResponse.Handlers);
		}

		[JsonProperty]
		public int AirlineId { get; private set; }

		[JsonProperty]
		public string FlightNumber { get; private set; }

		[JsonProperty]
		public int HandlerId { get; private set; }

		[JsonProperty]
		public string HandlerIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public DateTime LandDate { get; private set; }

		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[JsonProperty]
		public DateTime TakeoffDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7e9518928599f5f6d6e569cb1cafd9e4</Hash>
</Codenesium>*/