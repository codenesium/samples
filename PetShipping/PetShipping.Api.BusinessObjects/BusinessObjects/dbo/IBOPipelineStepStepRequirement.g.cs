using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStepStepRequirement
	{
		Task<CreateResponse<POCOPipelineStepStepRequirement>> Create(
			ApiPipelineStepStepRequirementModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStepStepRequirementModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOPipelineStepStepRequirement> Get(int id);

		Task<List<POCOPipelineStepStepRequirement>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>71c7bbc645f836bd1b41a4142b76780e</Hash>
</Codenesium>*/