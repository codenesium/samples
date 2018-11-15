using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostServerModelMapper
	{
		ApiPostServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostServerRequestModel request);

		ApiPostServerRequestModel MapServerResponseToRequest(
			ApiPostServerResponseModel response);

		ApiPostClientRequestModel MapServerResponseToClientRequest(
			ApiPostServerResponseModel response);

		JsonPatchDocument<ApiPostServerRequestModel> CreatePatch(ApiPostServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f3521769e988d43dcab0d5fc3d9326e2</Hash>
</Codenesium>*/