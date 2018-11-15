using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStepStatuService
	{
		Task<CreateResponse<ApiPipelineStepStatuServerResponseModel>> Create(
			ApiPipelineStepStatuServerRequestModel model);

		Task<UpdateResponse<ApiPipelineStepStatuServerResponseModel>> Update(int id,
		                                                                      ApiPipelineStepStatuServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepStatuServerResponseModel> Get(int id);

		Task<List<ApiPipelineStepStatuServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepServerResponseModel>> PipelineStepsByPipelineStepStatusId(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6d5fc7e56dc8562517bb6a5ff5fe723e</Hash>
</Codenesium>*/