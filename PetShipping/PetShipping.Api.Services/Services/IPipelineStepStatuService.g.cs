using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStepStatuService
	{
		Task<CreateResponse<ApiPipelineStepStatuResponseModel>> Create(
			ApiPipelineStepStatuRequestModel model);

		Task<UpdateResponse<ApiPipelineStepStatuResponseModel>> Update(int id,
		                                                                ApiPipelineStepStatuRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepStatuResponseModel> Get(int id);

		Task<List<ApiPipelineStepStatuResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepResponseModel>> PipelineStepsByPipelineStepStatusId(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5b3dd2fc9d4d8c4e2654471cd460d0ea</Hash>
</Codenesium>*/