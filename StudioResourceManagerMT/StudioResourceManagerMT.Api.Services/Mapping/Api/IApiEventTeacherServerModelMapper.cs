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
			int id,
			ApiEventTeacherServerRequestModel request);

		ApiEventTeacherServerRequestModel MapServerResponseToRequest(
			ApiEventTeacherServerResponseModel response);

		ApiEventTeacherClientRequestModel MapServerResponseToClientRequest(
			ApiEventTeacherServerResponseModel response);

		JsonPatchDocument<ApiEventTeacherServerRequestModel> CreatePatch(ApiEventTeacherServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>89ba73af4524cdd458b717cceb5e6eec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/