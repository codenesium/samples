using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepDestinationRequestModel : AbstractApiRequestModel
        {
                public ApiPipelineStepDestinationRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int destinationId,
                        int pipelineStepId)
                {
                        this.DestinationId = destinationId;
                        this.PipelineStepId = pipelineStepId;
                }

                [JsonProperty]
                public int DestinationId { get; private set; }

                [JsonProperty]
                public int PipelineStepId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d656bd4e81a9463ae7b2b65993440c85</Hash>
</Codenesium>*/