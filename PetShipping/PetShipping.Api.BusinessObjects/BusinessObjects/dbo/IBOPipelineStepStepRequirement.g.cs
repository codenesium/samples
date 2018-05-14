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
			PipelineStepStepRequirementModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStepStepRequirementModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStepStepRequirement Get(int id);

		List<POCOPipelineStepStepRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7b375f1eecdfde3ca102aed9eb702d2d</Hash>
</Codenesium>*/