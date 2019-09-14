using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>171a30216c6ac59b9358c8504e392cb0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/