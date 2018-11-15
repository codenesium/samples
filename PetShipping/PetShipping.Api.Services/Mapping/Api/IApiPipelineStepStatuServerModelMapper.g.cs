using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepStatuServerModelMapper
	{
		ApiPipelineStepStatuServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStepStatuServerRequestModel request);

		ApiPipelineStepStatuServerRequestModel MapServerResponseToRequest(
			ApiPipelineStepStatuServerResponseModel response);

		ApiPipelineStepStatuClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStepStatuServerResponseModel response);

		JsonPatchDocument<ApiPipelineStepStatuServerRequestModel> CreatePatch(ApiPipelineStepStatuServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>cf8563fe8fbcdf1964aa133f3cbb94da</Hash>
</Codenesium>*/