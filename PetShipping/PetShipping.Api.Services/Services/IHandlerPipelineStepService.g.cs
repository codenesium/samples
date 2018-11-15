using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IHandlerPipelineStepService
	{
		Task<CreateResponse<ApiHandlerPipelineStepServerResponseModel>> Create(
			ApiHandlerPipelineStepServerRequestModel model);

		Task<UpdateResponse<ApiHandlerPipelineStepServerResponseModel>> Update(int id,
		                                                                        ApiHandlerPipelineStepServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiHandlerPipelineStepServerResponseModel> Get(int id);

		Task<List<ApiHandlerPipelineStepServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e7d5e25857174437977c9cbcf6117767</Hash>
</Codenesium>*/