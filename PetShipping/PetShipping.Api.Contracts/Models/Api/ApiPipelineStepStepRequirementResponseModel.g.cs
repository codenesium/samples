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

                [JsonIgnore]
                public bool ShouldSerializeDetailsValue { get; set; } = true;

                public bool ShouldSerializeDetails()
                {
                        return this.ShouldSerializeDetailsValue;
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

                [JsonIgnore]
                public bool ShouldSerializeRequirementMetValue { get; set; } = true;

                public bool ShouldSerializeRequirementMet()
                {
                        return this.ShouldSerializeRequirementMetValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDetailsValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializePipelineStepIdValue = false;
                        this.ShouldSerializeRequirementMetValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>e6c02cecf95f39a1603fe637f7a4fe2c</Hash>
</Codenesium>*/