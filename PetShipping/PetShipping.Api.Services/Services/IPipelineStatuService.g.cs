using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStatuService
	{
		Task<CreateResponse<ApiPipelineStatuServerResponseModel>> Create(
			ApiPipelineStatuServerRequestModel model);

		Task<UpdateResponse<ApiPipelineStatuServerResponseModel>> Update(int id,
		                                                                  ApiPipelineStatuServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStatuServerResponseModel> Get(int id);

		Task<List<ApiPipelineStatuServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPipelineServerResponseModel>> PipelinesByPipelineStatusId(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7da458cda930c73125a77714f8a03201</Hash>
</Codenesium>*/