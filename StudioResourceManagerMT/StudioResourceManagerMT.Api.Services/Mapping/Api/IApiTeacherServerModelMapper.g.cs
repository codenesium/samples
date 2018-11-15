using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiTeacherServerModelMapper
	{
		ApiTeacherServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTeacherServerRequestModel request);

		ApiTeacherServerRequestModel MapServerResponseToRequest(
			ApiTeacherServerResponseModel response);

		ApiTeacherClientRequestModel MapServerResponseToClientRequest(
			ApiTeacherServerResponseModel response);

		JsonPatchDocument<ApiTeacherServerRequestModel> CreatePatch(ApiTeacherServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d135a908b14c77a854620f39e0910838</Hash>
</Codenesium>*/