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

		Task<List<ApiPipelineStepStepRequirementServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>c9bc6a04bb914a09a71eb9449241c475</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/