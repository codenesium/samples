using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiAirTransportResponseModel : AbstractApiResponseModel
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

                [Required]
                [JsonProperty]
                public int AirlineId { get; private set; }

                [Required]
                [JsonProperty]
                public string FlightNumber { get; private set; }

                [Required]
                [JsonProperty]
                public int HandlerId { get; private set; }

                [JsonProperty]
                public string HandlerIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime LandDate { get; private set; }

                [Required]
                [JsonProperty]
                public int PipelineStepId { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime TakeoffDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>3dd9ed50c812dc41adf59387eeab6769</Hash>
</Codenesium>*/