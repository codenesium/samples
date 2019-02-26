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
		public ApiHandlerServerResponseModel HandlerIdNavigation { get; private set; }

		public void SetHandlerIdNavigation(ApiHandlerServerResponseModel value)
		{
			this.HandlerIdNavigation = value;
		}

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
    <Hash>06bbdcbad969033f44f3da6a0c930294</Hash>
</Codenesium>*/