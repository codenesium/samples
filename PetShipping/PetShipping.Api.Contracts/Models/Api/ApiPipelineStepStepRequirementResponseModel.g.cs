using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepStepRequirementResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string details,
                        int pipelineStepId,
                        bool requirementMet)
                {
                        this.Id = id;
                        this.Details = details;
                        this.PipelineStepId = pipelineStepId;
                        this.RequirementMet = requirementMet;

                        this.PipelineStepIdEntity = nameof(ApiResponse.PipelineSteps);
                }

                public string Details { get; private set; }

                public int Id { get; private set; }

                public int PipelineStepId { get; private set; }

                public string PipelineStepIdEntity { get; set; }

                public bool RequirementMet { get; private set; }
        }
}

/*<Codenesium>
    <Hash>44bf8890d0263aa385c9d98779103dd6</Hash>
</Codenesium>*/