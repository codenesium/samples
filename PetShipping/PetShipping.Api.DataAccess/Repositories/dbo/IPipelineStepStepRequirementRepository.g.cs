using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStepRequirementRepository
	{
		Task<POCOPipelineStepStepRequirement> Create(ApiPipelineStepStepRequirementModel model);

		Task Update(int id,
		            ApiPipelineStepStepRequirementModel model);

		Task Delete(int id);

		Task<POCOPipelineStepStepRequirement> Get(int id);

		Task<List<POCOPipelineStepStepRequirement>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>28f730b5b9fe01e704a4a7ceb40c365a</Hash>
</Codenesium>*/