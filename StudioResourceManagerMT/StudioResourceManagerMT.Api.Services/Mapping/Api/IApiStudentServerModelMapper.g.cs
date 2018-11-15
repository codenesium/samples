using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiStudentServerModelMapper
	{
		ApiStudentServerResponseModel MapServerRequestToResponse(
			int id,
			ApiStudentServerRequestModel request);

		ApiStudentServerRequestModel MapServerResponseToRequest(
			ApiStudentServerResponseModel response);

		ApiStudentClientRequestModel MapServerResponseToClientRequest(
			ApiStudentServerResponseModel response);

		JsonPatchDocument<ApiStudentServerRequestModel> CreatePatch(ApiStudentServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e092c978da401006091239c365eaa7c2</Hash>
</Codenesium>*/