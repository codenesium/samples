using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiUnitOfficerServerModelMapper
	{
		ApiUnitOfficerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiUnitOfficerServerRequestModel request);

		ApiUnitOfficerServerRequestModel MapServerResponseToRequest(
			ApiUnitOfficerServerResponseModel response);

		ApiUnitOfficerClientRequestModel MapServerResponseToClientRequest(
			ApiUnitOfficerServerResponseModel response);

		JsonPatchDocument<ApiUnitOfficerServerRequestModel> CreatePatch(ApiUnitOfficerServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>52f90a8225f16f3aa391c3ac6879da3e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/