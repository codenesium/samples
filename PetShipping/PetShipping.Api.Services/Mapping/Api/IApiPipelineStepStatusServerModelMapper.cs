using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepStatusServerModelMapper
	{
		ApiPipelineStepStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStepStatusServerRequestModel request);

		ApiPipelineStepStatusServerRequestModel MapServerResponseToRequest(
			ApiPipelineStepStatusServerResponseModel response);

		ApiPipelineStepStatusClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStepStatusServerResponseModel response);

		JsonPatchDocument<ApiPipelineStepStatusServerRequestModel> CreatePatch(ApiPipelineStepStatusServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c185fd9e594325fff9a32758f6445f88</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/