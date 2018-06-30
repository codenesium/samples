using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IDALPipelineStepStepRequirementMapper
        {
                PipelineStepStepRequirement MapBOToEF(
                        BOPipelineStepStepRequirement bo);

                BOPipelineStepStepRequirement MapEFToBO(
                        PipelineStepStepRequirement efPipelineStepStepRequirement);

                List<BOPipelineStepStepRequirement> MapEFToBO(
                        List<PipelineStepStepRequirement> records);
        }
}

/*<Codenesium>
    <Hash>51d345eb4a11a5ab541bf4a5c0707a17</Hash>
</Codenesium>*/