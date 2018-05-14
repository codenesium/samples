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
			PipelineModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipeline Get(int id);

		List<POCOPipeline> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>68cf3da9b9fd4ec3525e2e48aec88b81</Hash>
</Codenesium>*/