using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public class ApiPipelineStepDestinationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int destinationId,
                        int id,
                        int pipelineStepId)
                {
                        this.DestinationId = destinationId;
                        this.Id = id;
                        this.PipelineStepId = pipelineStepId;

                        this.DestinationIdEntity = nameof(ApiResponse.Destinations);
                        this.PipelineStepIdEntity = nameof(ApiResponse.PipelineSteps);
                }

                public int DestinationId { get; private set; }

                public string DestinationIdEntity { get; set; }

                public int Id { get; private set; }

                public int PipelineStepId { get; private set; }

                public string PipelineStepIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeDestinationIdValue { get; set; } = true;

                public bool ShouldSerializeDestinationId()
                {
                        return this.ShouldSerializeDestinationIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePipelineStepIdValue { get; set; } = true;

                public bool ShouldSerializePipelineStepId()
                {
                        return this.ShouldSerializePipelineStepIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDestinationIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializePipelineStepIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>98342dca051e3b71ae096f3df211909f</Hash>
</Codenesium>*/