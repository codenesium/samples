using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStep
	{
		Task<CreateResponse<int>> Create(
			PipelineStepModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStepModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOPipelineStep GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipelineStep> GetWhereDirect(Expression<Func<EFPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e458e956dd0c7aa391d41b5f5c255742</Hash>
</Codenesium>*/