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
		Task<CreateResponse<POCOHandlerPipelineStep>> Create(
			ApiHandlerPipelineStepModel model);

		Task<ActionResponse> Update(int id,
		                            ApiHandlerPipelineStepModel model);

		Task<ActionResponse> Delete(int id);

		POCOHandlerPipelineStep Get(int id);

		List<POCOHandlerPipelineStep> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bf5acb9ac48fd93c3dddf34c228853a8</Hash>
</Codenesium>*/