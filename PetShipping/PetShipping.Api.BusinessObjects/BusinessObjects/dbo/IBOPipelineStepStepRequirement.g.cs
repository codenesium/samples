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

		ApiResponse GetById(int id);

		POCOPipelineStepStepRequirement GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipelineStepStepRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipelineStepStepRequirement> GetWhereDirect(Expression<Func<EFPipelineStepStepRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cfea3ebd963bc69936eebea72fc6d186</Hash>
</Codenesium>*/