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
		Task<CreateResponse<int>> Create(
			PipelineStepStepRequirementModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStepStepRequirementModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStepStepRequirement Get(int id);

		List<POCOPipelineStepStepRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>588c999726bd1d20a0d99d7aa5d9e81a</Hash>
</Codenesium>*/