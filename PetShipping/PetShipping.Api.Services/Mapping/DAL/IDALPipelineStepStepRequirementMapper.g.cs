using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>5cbb54821dfa579a146f727d80e54ad0</Hash>
</Codenesium>*/