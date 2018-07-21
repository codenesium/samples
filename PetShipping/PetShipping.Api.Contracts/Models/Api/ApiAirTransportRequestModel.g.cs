using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

                [JsonProperty]
                public string FlightNumber { get; private set; }

                [JsonProperty]
                public int HandlerId { get; private set; }

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
    <Hash>22ee76700f4ea95258af435670ccc3df</Hash>
</Codenesium>*/