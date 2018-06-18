using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IPipelineStepStepRequirementRepository
        {
                Task<PipelineStepStepRequirement> Create(PipelineStepStepRequirement item);

                Task Update(PipelineStepStepRequirement item);

                Task Delete(int id);

                Task<PipelineStepStepRequirement> Get(int id);

                Task<List<PipelineStepStepRequirement>> All(int limit = int.MaxValue, int offset = 0);

                Task<PipelineStep> GetPipelineStep(int pipelineStepId);
        }
}

/*<Codenesium>
    <Hash>5593d98952b05f969c8539c09d0d1315</Hash>
</Codenesium>*/