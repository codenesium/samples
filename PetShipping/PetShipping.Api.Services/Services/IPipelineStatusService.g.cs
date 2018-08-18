using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStatusService
	{
		Task<CreateResponse<ApiPipelineStatusResponseModel>> Create(
			ApiPipelineStatusRequestModel model);

		Task<UpdateResponse<ApiPipelineStatusResponseModel>> Update(int id,
		                                                             ApiPipelineStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStatusResponseModel> Get(int id);

		Task<List<ApiPipelineStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineResponseModel>> Pipelines(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9a06077d67b0a4a0d177e337cea40327</Hash>
</Codenesium>*/