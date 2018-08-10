using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiPipelineStatusModelMapper
	{
		ApiPipelineStatusResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStatusRequestModel request);

		ApiPipelineStatusRequestModel MapResponseToRequest(
			ApiPipelineStatusResponseModel response);

		JsonPatchDocument<ApiPipelineStatusRequestModel> CreatePatch(ApiPipelineStatusRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3416c56ced0cf122850125a768446571</Hash>
</Codenesium>*/