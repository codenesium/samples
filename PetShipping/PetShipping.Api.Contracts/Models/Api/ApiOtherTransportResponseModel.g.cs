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
        }
}

/*<Codenesium>
    <Hash>677ed2abc6df5f145f6c1f5fd3c7a763</Hash>
</Codenesium>*/