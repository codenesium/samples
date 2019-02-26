using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiAirTransportClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int airlineId,
			string flightNumber,
			int handlerId,
			DateTime landDate,
			int pipelineStepId,
			DateTime takeoffDate)
		{
			this.Id = id;
			this.AirlineId = airlineId;
			this.FlightNumber = flightNumber;
			this.HandlerId = handlerId;
			this.LandDate = landDate;
			this.PipelineStepId = pipelineStepId;
			this.TakeoffDate = takeoffDate;

			this.HandlerIdEntity = nameof(ApiResponse.Handlers);
		}

		[JsonProperty]
		public ApiHandlerClientResponseModel HandlerIdNavigation { get; private set; }

		public void SetHandlerIdNavigation(ApiHandlerClientResponseModel value)
		{
			this.HandlerIdNavigation = value;
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
    <Hash>29f591dc9119a9787cb2bf02f6d0466e</Hash>
</Codenesium>*/