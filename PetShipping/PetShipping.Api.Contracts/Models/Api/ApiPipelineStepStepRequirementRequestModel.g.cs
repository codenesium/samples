using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepStepRequirementRequestModel : AbstractApiRequestModel
        {
                public ApiPipelineStepStepRequirementRequestModel()
                        : base()
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
    <Hash>b1c69041e9440fbbd595f26e58a3558e</Hash>
</Codenesium>*/