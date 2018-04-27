using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOHandlerPipelineStep
	{
		Task<CreateResponse<int>> Create(
			HandlerPipelineStepModel model);

		Task<ActionResponse> Update(int id,
		                            HandlerPipelineStepModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOHandlerPipelineStep GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFHandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOHandlerPipelineStep> GetWhereDirect(Expression<Func<EFHandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>19b7c692dfd5aab9cade3f00f9b82cfb</Hash>
</Codenesium>*/