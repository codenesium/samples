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
			string flightNumber,
			int handlerId,
			int id,
			DateTime landDate,
			int pipelineStepId,
			DateTime takeoffDate)
		{
			this.FlightNumber = flightNumber;
			this.HandlerId = handlerId;
			this.Id = id;
			this.LandDate = landDate;
			this.PipelineStepId = pipelineStepId;
			this.TakeoffDate = takeoffDate;
		}

		[JsonProperty]
		public string FlightNumber { get; private set; } = default(string);

		[JsonProperty]
		public int HandlerId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; } = default(int);

		[JsonProperty]
		public DateTime LandDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int PipelineStepId { get; private set; } = default(int);

		[JsonProperty]
		public DateTime TakeoffDate { get; private set; } = SqlDateTime.MinValue.Value;
	}
}

/*<Codenesium>
    <Hash>a8ed92d82d42c643a4f85a4f40523a87</Hash>
</Codenesium>*/