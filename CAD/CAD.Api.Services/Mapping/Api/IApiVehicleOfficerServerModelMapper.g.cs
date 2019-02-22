using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehicleOfficerServerModelMapper
	{
		ApiVehicleOfficerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVehicleOfficerServerRequestModel request);

		ApiVehicleOfficerServerRequestModel MapServerResponseToRequest(
			ApiVehicleOfficerServerResponseModel response);

		ApiVehicleOfficerClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleOfficerServerResponseModel response);

		JsonPatchDocument<ApiVehicleOfficerServerRequestModel> CreatePatch(ApiVehicleOfficerServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>098be92b6ebcd6f167e239f5ef245401</Hash>
</Codenesium>*/