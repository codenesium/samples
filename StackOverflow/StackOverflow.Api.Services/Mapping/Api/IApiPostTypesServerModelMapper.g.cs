using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostTypesServerModelMapper
	{
		ApiPostTypesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostTypesServerRequestModel request);

		ApiPostTypesServerRequestModel MapServerResponseToRequest(
			ApiPostTypesServerResponseModel response);

		ApiPostTypesClientRequestModel MapServerResponseToClientRequest(
			ApiPostTypesServerResponseModel response);

		JsonPatchDocument<ApiPostTypesServerRequestModel> CreatePatch(ApiPostTypesServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f4da642154160679b88bce9453b47288</Hash>
</Codenesium>*/