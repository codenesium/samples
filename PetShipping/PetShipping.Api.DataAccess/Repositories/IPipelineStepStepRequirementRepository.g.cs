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

                Task<List<PipelineStepStepRequirement>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>726e732bf809110dceed74c01443b1db</Hash>
</Codenesium>*/