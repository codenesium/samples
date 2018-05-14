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

		POCOPipelineStepStepRequirement Get(int id);

		List<POCOPipelineStepStepRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d23b6d55e8efa7627f8af384e02f0938</Hash>
</Codenesium>*/