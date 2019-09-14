using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiLinkLogServerModelMapper
	{
		ApiLinkLogServerResponseModel MapServerRequestToResponse(
			int id,
			ApiLinkLogServerRequestModel request);

		ApiLinkLogServerRequestModel MapServerResponseToRequest(
			ApiLinkLogServerResponseModel response);

		ApiLinkLogClientRequestModel MapServerResponseToClientRequest(
			ApiLinkLogServerResponseModel response);

		JsonPatchDocument<ApiLinkLogServerRequestModel> CreatePatch(ApiLinkLogServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b3745b83d174c7e793253a5f39c7ce5e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/