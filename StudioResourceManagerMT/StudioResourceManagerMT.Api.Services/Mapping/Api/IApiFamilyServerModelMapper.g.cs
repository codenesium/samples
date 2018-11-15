using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>9d4abf94c8ca3ef9cc9fbeb54bbace31</Hash>
</Codenesium>*/