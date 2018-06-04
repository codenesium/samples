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
    <Hash>6141e6546fe7dad2ab899814c1f73241</Hash>
</Codenesium>*/