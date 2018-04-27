using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipeline
	{
		Task<CreateResponse<int>> Create(
			PipelineModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOPipeline GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipeline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipeline> GetWhereDirect(Expression<Func<EFPipeline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>832d286c7a78f66c1466e3d331757399</Hash>
</Codenesium>*/