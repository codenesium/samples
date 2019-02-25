using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStepStatusService
	{
		Task<CreateResponse<ApiPipelineStepStatusServerResponseModel>> Create(
			ApiPipelineStepStatusServerRequestModel model);

		Task<UpdateResponse<ApiPipelineStepStatusServerResponseModel>> Update(int id,
		                                                                       ApiPipelineStepStatusServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepStatusServerResponseModel> Get(int id);

		Task<List<ApiPipelineStepStatusServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPipelineStepServerResponseModel>> PipelineStepsByPipelineStepStatusId(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a981d09782e4d63d08618b0c0f6be6f0</Hash>
</Codenesium>*/