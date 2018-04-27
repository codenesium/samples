using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStepRequirementRepository
	{
		int Create(PipelineStepStepRequirementModel model);

		void Update(int id,
		            PipelineStepStepRequirementModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOPipelineStepStepRequirement GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipelineStepStepRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipelineStepStepRequirement> GetWhereDirect(Expression<Func<EFPipelineStepStepRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>80bbebb6231e88a45ab4b02543d1da1e</Hash>
</Codenesium>*/