using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiBadgesServerModelMapper
	{
		ApiBadgesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiBadgesServerRequestModel request);

		ApiBadgesServerRequestModel MapServerResponseToRequest(
			ApiBadgesServerResponseModel response);

		ApiBadgesClientRequestModel MapServerResponseToClientRequest(
			ApiBadgesServerResponseModel response);

		JsonPatchDocument<ApiBadgesServerRequestModel> CreatePatch(ApiBadgesServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e080ce780b81361450e589a0e63913a2</Hash>
</Codenesium>*/