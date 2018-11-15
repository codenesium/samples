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

		Task<List<ApiPipelineStatuServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineServerResponseModel>> PipelinesByPipelineStatusId(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ba1bccb85b5d82af4af80109e858b422</Hash>
</Codenesium>*/