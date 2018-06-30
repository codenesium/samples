using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiOtherTransportResponseModel : AbstractApiResponseModel
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

                public int HandlerId { get; private set; }

                public string HandlerIdEntity { get; set; }

                public int Id { get; private set; }

                public int PipelineStepId { get; private set; }

                public string PipelineStepIdEntity { get; set; }

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
                public bool ShouldSerializePipelineStepIdValue { get; set; } = true;

                public bool ShouldSerializePipelineStepId()
                {
                        return this.ShouldSerializePipelineStepIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeHandlerIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializePipelineStepIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>703632355c7a62f98c826e423721e80a</Hash>
</Codenesium>*/