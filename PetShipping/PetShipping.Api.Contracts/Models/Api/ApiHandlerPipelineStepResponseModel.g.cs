using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiHandlerPipelineStepResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int handlerId,
                        int pipelineStepId)
                {
                        this.Id = id;
                        this.HandlerId = handlerId;
                        this.PipelineStepId = pipelineStepId;

                        this.HandlerIdEntity = nameof(ApiResponse.Handlers);
                        this.PipelineStepIdEntity = nameof(ApiResponse.PipelineSteps);
                }

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
                public int PipelineStepId { get; private set; }

                [JsonProperty]
                public string PipelineStepIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>7d2dba947080ff6352adfea75db43e42</Hash>
</Codenesium>*/