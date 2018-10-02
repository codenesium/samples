using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStatuService
	{
		Task<CreateResponse<ApiPipelineStatuResponseModel>> Create(
			ApiPipelineStatuRequestModel model);

		Task<UpdateResponse<ApiPipelineStatuResponseModel>> Update(int id,
		                                                            ApiPipelineStatuRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStatuResponseModel> Get(int id);

		Task<List<ApiPipelineStatuResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineResponseModel>> Pipelines(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d273162ff8d61aefc27074cd04b1c21a</Hash>
</Codenesium>*/