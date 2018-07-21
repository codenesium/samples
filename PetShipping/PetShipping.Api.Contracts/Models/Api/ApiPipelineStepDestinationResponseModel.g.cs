using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepDestinationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int destinationId,
                        int pipelineStepId)
                {
                        this.Id = id;
                        this.DestinationId = destinationId;
                        this.PipelineStepId = pipelineStepId;

                        this.DestinationIdEntity = nameof(ApiResponse.Destinations);
                        this.PipelineStepIdEntity = nameof(ApiResponse.PipelineSteps);
                }

                [Required]
                [JsonProperty]
                public int DestinationId { get; private set; }

                [JsonProperty]
                public string DestinationIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public int PipelineStepId { get; private set; }

                [JsonProperty]
                public string PipelineStepIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>cb0c0212b38a43139bb101e6cf673b12</Hash>
</Codenesium>*/