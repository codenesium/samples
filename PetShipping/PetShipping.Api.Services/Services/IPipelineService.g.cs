using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineService
	{
		Task<CreateResponse<ApiPipelineServerResponseModel>> Create(
			ApiPipelineServerRequestModel model);

		Task<UpdateResponse<ApiPipelineServerResponseModel>> Update(int id,
		                                                             ApiPipelineServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineServerResponseModel> Get(int id);

		Task<List<ApiPipelineServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>0afac1cb384497dd29c64c5973438e18</Hash>
</Codenesium>*/