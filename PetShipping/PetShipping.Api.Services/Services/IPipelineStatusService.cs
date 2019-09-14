using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStatusService
	{
		Task<CreateResponse<ApiPipelineStatusServerResponseModel>> Create(
			ApiPipelineStatusServerRequestModel model);

		Task<UpdateResponse<ApiPipelineStatusServerResponseModel>> Update(int id,
		                                                                   ApiPipelineStatusServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStatusServerResponseModel> Get(int id);

		Task<List<ApiPipelineStatusServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPipelineServerResponseModel>> PipelinesByPipelineStatusId(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5765add9ed5491aff5a850f865520a0e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/