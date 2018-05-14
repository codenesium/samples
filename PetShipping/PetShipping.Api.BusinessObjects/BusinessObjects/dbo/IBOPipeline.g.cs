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

		POCOPipeline Get(int id);

		List<POCOPipeline> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>66e5c37ec40d6d55e58338715e0dc8ef</Hash>
</Codenesium>*/