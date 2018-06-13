using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiAirTransportResponseModel: AbstractApiResponseModel
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

                public int AirlineId { get; private set; }

                public string FlightNumber { get; private set; }

                public int HandlerId { get; private set; }

                public string HandlerIdEntity { get; set; }

                public int Id { get; private set; }

                public DateTime LandDate { get; private set; }

                public int PipelineStepId { get; private set; }

                public DateTime TakeoffDate { get; private set; }

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

                public virtual void DisableAllFields()
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
    <Hash>676cefe98ee7cb20682aa81a8496d293</Hash>
</Codenesium>*/