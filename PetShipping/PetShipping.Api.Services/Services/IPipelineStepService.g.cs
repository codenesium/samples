using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStepService
	{
		Task<CreateResponse<ApiPipelineStepServerResponseModel>> Create(
			ApiPipelineStepServerRequestModel model);

		Task<UpdateResponse<ApiPipelineStepServerResponseModel>> Update(int id,
		                                                                 ApiPipelineStepServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepServerResponseModel> Get(int id);

		Task<List<ApiPipelineStepServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiHandlerPipelineStepServerResponseModel>> HandlerPipelineStepsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiOtherTransportServerResponseModel>> OtherTransportsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepDestinationServerResponseModel>> PipelineStepDestinationsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepNoteServerResponseModel>> PipelineStepNotesByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepStepRequirementServerResponseModel>> PipelineStepStepRequirementsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1f8d461e0f22b3ec3b97f6ec533945ad</Hash>
</Codenesium>*/