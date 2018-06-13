using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPipelineStepDestinationResponseModel: AbstractApiResponseModel
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
    <Hash>8962a28b500fe48fe60aef020b221833</Hash>
</Codenesium>*/