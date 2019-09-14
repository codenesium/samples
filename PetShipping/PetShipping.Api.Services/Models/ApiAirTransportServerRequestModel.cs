using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiAirTransportServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiAirTransportServerRequestModel()
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

		[Required]
		[JsonProperty]
		public int AirlineId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string FlightNumber { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int HandlerId { get; private set; }

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
    <Hash>c6092d14e69e12a7ee4fd9ba9ca6a230</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/