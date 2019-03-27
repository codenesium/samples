using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiEventTeacherServerModelMapper
	{
		ApiEventTeacherServerResponseModel MapServerRequestToResponse(
			int eventId,
			ApiEventTeacherServerRequestModel request);

		ApiEventTeacherServerRequestModel MapServerResponseToRequest(
			ApiEventTeacherServerResponseModel response);

		ApiEventTeacherClientRequestModel MapServerResponseToClientRequest(
			ApiEventTeacherServerResponseModel response);

		JsonPatchDocument<ApiEventTeacherServerRequestModel> CreatePatch(ApiEventTeacherServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>242fcbda329cc67addad3a96f90198dd</Hash>
</Codenesium>*/