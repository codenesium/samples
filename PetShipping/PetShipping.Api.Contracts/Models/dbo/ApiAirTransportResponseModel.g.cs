using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiAirTransportResponseModel: AbstractApiResponseModel
	{
		public ApiAirTransportResponseModel() : base()
		{}

		public void SetProperties(
			int airlineId,
			string flightNumber,
			int handlerId,
			int id,
			DateTime landDate,
			int pipelineStepId,
			DateTime takeoffDate)
		{
			this.AirlineId = airlineId.ToInt();
			this.FlightNumber = flightNumber;
			this.Id = id.ToInt();
			this.LandDate = landDate.ToDateTime();
			this.PipelineStepId = pipelineStepId.ToInt();
			this.TakeoffDate = takeoffDate.ToDateTime();

			this.HandlerId = new ReferenceEntity<int>(handlerId,
			                                          nameof(ApiResponse.Handlers));
		}

		public int AirlineId { get; set; }
		public string FlightNumber { get; set; }
		public ReferenceEntity<int> HandlerId { get; set; }
		public int Id { get; set; }
		public DateTime LandDate { get; set; }
		public int PipelineStepId { get; set; }
		public DateTime TakeoffDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAirlineIdValue { get; set; } = true;

		public bool ShouldSerializeAirlineId()
		{
			return this.ShouldSerializeAirlineIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFlightNumberValue { get; set; } = true;

		public bool ShouldSerializeFlightNumber()
		{
			return this.ShouldSerializeFlightNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeHandlerIdValue { get; set; } = true;

		public bool ShouldSerializeHandlerId()
		{
			return this.ShouldSerializeHandlerIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLandDateValue { get; set; } = true;

		public bool ShouldSerializeLandDate()
		{
			return this.ShouldSerializeLandDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStepIdValue { get; set; } = true;

		public bool ShouldSerializePipelineStepId()
		{
			return this.ShouldSerializePipelineStepIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTakeoffDateValue { get; set; } = true;

		public bool ShouldSerializeTakeoffDate()
		{
			return this.ShouldSerializeTakeoffDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAirlineIdValue = false;
			this.ShouldSerializeFlightNumberValue = false;
			this.ShouldSerializeHandlerIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeLandDateValue = false;
			this.ShouldSerializePipelineStepIdValue = false;
			this.ShouldSerializeTakeoffDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>53a4c873fed2a465842939c6c40b9885</Hash>
</Codenesium>*/