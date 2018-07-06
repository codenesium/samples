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

                public int AirlineId { get; private set; }

                public string FlightNumber { get; private set; }

                public int HandlerId { get; private set; }

                public string HandlerIdEntity { get; set; }

                public int Id { get; private set; }

                public DateTime LandDate { get; private set; }

                public int PipelineStepId { get; private set; }

                public DateTime TakeoffDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e783bd22c72227eba5f1a9dea9496175</Hash>
</Codenesium>*/