using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiAirTransportRequestModel : AbstractApiRequestModel
	{
		public ApiAirTransportRequestModel()
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

		[Required]
		[JsonProperty]
		public string FlightNumber { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int HandlerId { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime LandDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int PipelineStepId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime TakeoffDate { get; private set; } = SqlDateTime.MinValue.Value;
	}
}

/*<Codenesium>
    <Hash>55197257333499bcafdfe6517e852e1c</Hash>
</Codenesium>*/