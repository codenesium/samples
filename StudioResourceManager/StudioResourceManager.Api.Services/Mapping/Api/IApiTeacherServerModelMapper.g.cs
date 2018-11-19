using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>1f99eccc47b23bd0dd96286624b71b10</Hash>
</Codenesium>*/