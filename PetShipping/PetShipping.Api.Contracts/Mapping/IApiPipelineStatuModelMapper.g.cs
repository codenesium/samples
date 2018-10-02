using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiPipelineStatuModelMapper
	{
		ApiPipelineStatuResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStatuRequestModel request);

		ApiPipelineStatuRequestModel MapResponseToRequest(
			ApiPipelineStatuResponseModel response);

		JsonPatchDocument<ApiPipelineStatuRequestModel> CreatePatch(ApiPipelineStatuRequestModel model);
	}
}

/*<Codenesium>
    <Hash>13c92122c4b58647d0fb4ca4a8f64b6b</Hash>
</Codenesium>*/