using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepServerModelMapper
	{
		ApiPipelineStepServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStepServerRequestModel request);

		ApiPipelineStepServerRequestModel MapServerResponseToRequest(
			ApiPipelineStepServerResponseModel response);

		ApiPipelineStepClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStepServerResponseModel response);

		JsonPatchDocument<ApiPipelineStepServerRequestModel> CreatePatch(ApiPipelineStepServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c652687c4c4fbedf1d5cdc44a9791015</Hash>
</Codenesium>*/