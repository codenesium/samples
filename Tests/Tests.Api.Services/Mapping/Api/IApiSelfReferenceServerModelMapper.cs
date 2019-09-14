using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiSelfReferenceServerModelMapper
	{
		ApiSelfReferenceServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSelfReferenceServerRequestModel request);

		ApiSelfReferenceServerRequestModel MapServerResponseToRequest(
			ApiSelfReferenceServerResponseModel response);

		ApiSelfReferenceClientRequestModel MapServerResponseToClientRequest(
			ApiSelfReferenceServerResponseModel response);

		JsonPatchDocument<ApiSelfReferenceServerRequestModel> CreatePatch(ApiSelfReferenceServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8c6c74a9aae3a28e88faa519fb41f379</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/