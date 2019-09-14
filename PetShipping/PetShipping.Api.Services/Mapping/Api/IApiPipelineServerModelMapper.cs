using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineServerModelMapper
	{
		ApiPipelineServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineServerRequestModel request);

		ApiPipelineServerRequestModel MapServerResponseToRequest(
			ApiPipelineServerResponseModel response);

		ApiPipelineClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineServerResponseModel response);

		JsonPatchDocument<ApiPipelineServerRequestModel> CreatePatch(ApiPipelineServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>cb1b87dfc6d758979243a27f7a95a64b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/