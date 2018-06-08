using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOPipelineStepStepRequirement: AbstractBusinessObject
        {
                public BOPipelineStepStepRequirement() : base()
                {
                }

                public void SetProperties(int id,
                                          string details,
                                          int pipelineStepId,
                                          bool requirementMet)
                {
                        this.Details = details;
                        this.Id = id;
                        this.PipelineStepId = pipelineStepId;
                        this.RequirementMet = requirementMet;
                }

                public string Details { get; private set; }

                public int Id { get; private set; }

                public int PipelineStepId { get; private set; }

                public bool RequirementMet { get; private set; }
        }
}

/*<Codenesium>
    <Hash>94bc9d0633a690b43cc13f3e6c597255</Hash>
</Codenesium>*/