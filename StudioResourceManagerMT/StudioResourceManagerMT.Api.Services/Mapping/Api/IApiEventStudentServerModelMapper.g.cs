using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiEventStudentServerModelMapper
	{
		ApiEventStudentServerResponseModel MapServerRequestToResponse(
			int eventId,
			ApiEventStudentServerRequestModel request);

		ApiEventStudentServerRequestModel MapServerResponseToRequest(
			ApiEventStudentServerResponseModel response);

		ApiEventStudentClientRequestModel MapServerResponseToClientRequest(
			ApiEventStudentServerResponseModel response);

		JsonPatchDocument<ApiEventStudentServerRequestModel> CreatePatch(ApiEventStudentServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>23684b51e3937b111f3a1e95f5fcd841</Hash>
</Codenesium>*/