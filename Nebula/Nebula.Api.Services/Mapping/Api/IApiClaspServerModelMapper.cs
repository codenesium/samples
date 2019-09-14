using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiClaspServerModelMapper
	{
		ApiClaspServerResponseModel MapServerRequestToResponse(
			int id,
			ApiClaspServerRequestModel request);

		ApiClaspServerRequestModel MapServerResponseToRequest(
			ApiClaspServerResponseModel response);

		ApiClaspClientRequestModel MapServerResponseToClientRequest(
			ApiClaspServerResponseModel response);

		JsonPatchDocument<ApiClaspServerRequestModel> CreatePatch(ApiClaspServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d93b659bacc9f36159076045a1863d36</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/