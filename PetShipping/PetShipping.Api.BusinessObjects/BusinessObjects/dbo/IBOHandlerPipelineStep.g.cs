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
		Task<CreateResponse<ApiHandlerPipelineStepResponseModel>> Create(
			ApiHandlerPipelineStepRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiHandlerPipelineStepRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiHandlerPipelineStepResponseModel> Get(int id);

		Task<List<ApiHandlerPipelineStepResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bdcc169260a3c8a12fa4aa85484cf4d0</Hash>
</Codenesium>*/