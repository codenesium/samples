using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiEventStudentServerModelMapper
	{
		ApiEventStudentServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventStudentServerRequestModel request);

		ApiEventStudentServerRequestModel MapServerResponseToRequest(
			ApiEventStudentServerResponseModel response);

		ApiEventStudentClientRequestModel MapServerResponseToClientRequest(
			ApiEventStudentServerResponseModel response);

		JsonPatchDocument<ApiEventStudentServerRequestModel> CreatePatch(ApiEventStudentServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>dcc5b11dc5a4a3bdfb3166a3de464366</Hash>
</Codenesium>*/