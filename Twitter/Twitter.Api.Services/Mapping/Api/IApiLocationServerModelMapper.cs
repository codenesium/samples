using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public partial interface IApiLocationServerModelMapper
	{
		ApiLocationServerResponseModel MapServerRequestToResponse(
			int locationId,
			ApiLocationServerRequestModel request);

		ApiLocationServerRequestModel MapServerResponseToRequest(
			ApiLocationServerResponseModel response);

		ApiLocationClientRequestModel MapServerResponseToClientRequest(
			ApiLocationServerResponseModel response);

		JsonPatchDocument<ApiLocationServerRequestModel> CreatePatch(ApiLocationServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>92b17c00a47a9bf9ea2b612e84c1e68a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/