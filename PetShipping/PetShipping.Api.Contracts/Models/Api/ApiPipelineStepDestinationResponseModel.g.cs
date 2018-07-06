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

                public int DestinationId { get; private set; }

                public string DestinationIdEntity { get; set; }

                public int Id { get; private set; }

                public int PipelineStepId { get; private set; }

                public string PipelineStepIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>8fb790a2871d469b32b1c0e116c52774</Hash>
</Codenesium>*/