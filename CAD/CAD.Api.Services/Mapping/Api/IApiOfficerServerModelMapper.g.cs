using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiOfficerServerModelMapper
	{
		ApiOfficerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiOfficerServerRequestModel request);

		ApiOfficerServerRequestModel MapServerResponseToRequest(
			ApiOfficerServerResponseModel response);

		ApiOfficerClientRequestModel MapServerResponseToClientRequest(
			ApiOfficerServerResponseModel response);

		JsonPatchDocument<ApiOfficerServerRequestModel> CreatePatch(ApiOfficerServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f0879ff567ed2d01ecfcae03d50272c7</Hash>
</Codenesium>*/