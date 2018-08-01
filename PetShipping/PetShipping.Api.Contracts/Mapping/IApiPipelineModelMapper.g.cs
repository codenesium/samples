using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiPipelineModelMapper
	{
		ApiPipelineResponseModel MapRequestToResponse(
			int id,
			ApiPipelineRequestModel request);

		ApiPipelineRequestModel MapResponseToRequest(
			ApiPipelineResponseModel response);

		JsonPatchDocument<ApiPipelineRequestModel> CreatePatch(ApiPipelineRequestModel model);
	}
}

/*<Codenesium>
    <Hash>57b9084268f6e0f58f619807d0aef9e3</Hash>
</Codenesium>*/