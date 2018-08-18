using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiPipelineModelMapper
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
    <Hash>146a5f517970c9dc639219ed5c7bd941</Hash>
</Codenesium>*/