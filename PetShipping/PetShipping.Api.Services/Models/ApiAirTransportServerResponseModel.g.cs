using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiAirTransportServerResponseModel : AbstractApiServerResponseModel
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
		}

		[JsonProperty]
		public int AirlineId { get; private set; }

		[JsonProperty]
		public string FlightNumber { get; private set; }

		[JsonProperty]
		public int HandlerId { get; private set; }

		[JsonProperty]
		public string HandlerIdEntity { get; private set; } = RouteConstants.Handlers;

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
    <Hash>f971bef2048e3ee443532913fbf7a4c5</Hash>
</Codenesium>*/