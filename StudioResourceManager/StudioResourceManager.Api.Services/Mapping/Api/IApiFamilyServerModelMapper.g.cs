using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiFamilyServerModelMapper
	{
		ApiFamilyServerResponseModel MapServerRequestToResponse(
			int id,
			ApiFamilyServerRequestModel request);

		ApiFamilyServerRequestModel MapServerResponseToRequest(
			ApiFamilyServerResponseModel response);

		ApiFamilyClientRequestModel MapServerResponseToClientRequest(
			ApiFamilyServerResponseModel response);

		JsonPatchDocument<ApiFamilyServerRequestModel> CreatePatch(ApiFamilyServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>af6521fc0df23d9976ada2468edb08b2</Hash>
</Codenesium>*/