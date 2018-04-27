using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStepStatus
	{
		Task<CreateResponse<int>> Create(
			PipelineStepStatusModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStepStatusModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOPipelineStepStatus GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipelineStepStatus> GetWhereDirect(Expression<Func<EFPipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f0d54a30b594e9f1db18ce563cffa95b</Hash>
</Codenesium>*/