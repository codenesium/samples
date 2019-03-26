using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiBadgeServerModelMapper
	{
		ApiBadgeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiBadgeServerRequestModel request);

		ApiBadgeServerRequestModel MapServerResponseToRequest(
			ApiBadgeServerResponseModel response);

		ApiBadgeClientRequestModel MapServerResponseToClientRequest(
			ApiBadgeServerResponseModel response);

		JsonPatchDocument<ApiBadgeServerRequestModel> CreatePatch(ApiBadgeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>bdff76d5c56f803d917eb7063a741960</Hash>
</Codenesium>*/