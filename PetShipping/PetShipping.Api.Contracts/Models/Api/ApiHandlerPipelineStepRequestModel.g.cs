using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiHandlerPipelineStepRequestModel : AbstractApiRequestModel
        {
                public ApiHandlerPipelineStepRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int handlerId,
                        int pipelineStepId)
                {
                        this.HandlerId = handlerId;
                        this.PipelineStepId = pipelineStepId;
                }

                [JsonProperty]
                public int HandlerId { get; private set; }

                [JsonProperty]
                public int PipelineStepId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>02badf8ede05e20531c3c974d2408bee</Hash>
</Codenesium>*/