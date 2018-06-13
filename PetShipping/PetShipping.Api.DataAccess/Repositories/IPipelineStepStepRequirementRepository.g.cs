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

                Task<List<PipelineStepStepRequirement>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>079431881a9c061c365ebca8470b7656</Hash>
</Codenesium>*/