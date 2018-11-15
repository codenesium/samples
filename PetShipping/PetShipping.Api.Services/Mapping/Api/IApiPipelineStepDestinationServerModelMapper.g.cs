using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepDestinationServerModelMapper
	{
		ApiPipelineStepDestinationServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStepDestinationServerRequestModel request);

		ApiPipelineStepDestinationServerRequestModel MapServerResponseToRequest(
			ApiPipelineStepDestinationServerResponseModel response);

		ApiPipelineStepDestinationClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStepDestinationServerResponseModel response);

		JsonPatchDocument<ApiPipelineStepDestinationServerRequestModel> CreatePatch(ApiPipelineStepDestinationServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0626267063102983379b4d84187be307</Hash>
</Codenesium>*/