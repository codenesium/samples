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
    <Hash>d51adc60576a590722ec93b5d4f4f69f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/