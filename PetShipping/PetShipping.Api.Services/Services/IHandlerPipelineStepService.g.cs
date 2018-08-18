using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IHandlerPipelineStepService
	{
		Task<CreateResponse<ApiHandlerPipelineStepResponseModel>> Create(
			ApiHandlerPipelineStepRequestModel model);

		Task<UpdateResponse<ApiHandlerPipelineStepResponseModel>> Update(int id,
		                                                                  ApiHandlerPipelineStepRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiHandlerPipelineStepResponseModel> Get(int id);

		Task<List<ApiHandlerPipelineStepResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>39dabfbeb46ca693107a131162a9e7f0</Hash>
</Codenesium>*/