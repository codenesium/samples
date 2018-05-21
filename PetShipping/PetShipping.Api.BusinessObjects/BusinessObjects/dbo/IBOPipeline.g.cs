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
		Task<CreateResponse<POCOPipeline>> Create(
			ApiPipelineModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOPipeline> Get(int id);

		Task<List<POCOPipeline>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9fd7bbcbe65db781fb17d119e2f16063</Hash>
</Codenesium>*/