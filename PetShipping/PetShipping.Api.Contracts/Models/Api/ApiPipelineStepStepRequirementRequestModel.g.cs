using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepStepRequirementRequestModel: AbstractApiRequestModel
        {
                public ApiPipelineStepStepRequirementRequestModel() : base()
                {
                }

                public void SetProperties(
                        string details,
                        int pipelineStepId,
                        bool requirementMet)
                {
                        this.Details = details;
                        this.PipelineStepId = pipelineStepId;
                        this.RequirementMet = requirementMet;
                }

                private string details;

                [Required]
                public string Details
                {
                        get
                        {
                                return this.details;
                        }

                        set
                        {
                                this.details = value;
                        }
                }

                private int pipelineStepId;

                [Required]
                public int PipelineStepId
                {
                        get
                        {
                                return this.pipelineStepId;
                        }

                        set
                        {
                                this.pipelineStepId = value;
                        }
                }

                private bool requirementMet;

                [Required]
                public bool RequirementMet
                {
                        get
                        {
                                return this.requirementMet;
                        }

                        set
                        {
                                this.requirementMet = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>8be13845d5968ff209f0c03a91877d5c</Hash>
</Codenesium>*/