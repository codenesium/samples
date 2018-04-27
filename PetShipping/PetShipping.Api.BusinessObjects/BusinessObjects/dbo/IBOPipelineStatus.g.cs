using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStatus
	{
		Task<CreateResponse<int>> Create(
			PipelineStatusModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStatusModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOPipelineStatus GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipelineStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipelineStatus> GetWhereDirect(Expression<Func<EFPipelineStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0d6acc409cf89680144404be6ec5d65d</Hash>
</Codenesium>*/