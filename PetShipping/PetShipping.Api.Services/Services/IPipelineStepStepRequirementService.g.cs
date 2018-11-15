using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStepStepRequirementService
	{
		Task<CreateResponse<ApiPipelineStepStepRequirementServerResponseModel>> Create(
			ApiPipelineStepStepRequirementServerRequestModel model);

		Task<UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel>> Update(int id,
		                                                                                ApiPipelineStepStepRequirementServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepStepRequirementServerResponseModel> Get(int id);

		Task<List<ApiPipelineStepStepRequirementServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b76f97ba91dd05e4cf6d08763b4689dc</Hash>
</Codenesium>*/