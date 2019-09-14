using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiOfficerCapabilitiesServerModelMapper
	{
		ApiOfficerCapabilitiesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiOfficerCapabilitiesServerRequestModel request);

		ApiOfficerCapabilitiesServerRequestModel MapServerResponseToRequest(
			ApiOfficerCapabilitiesServerResponseModel response);

		ApiOfficerCapabilitiesClientRequestModel MapServerResponseToClientRequest(
			ApiOfficerCapabilitiesServerResponseModel response);

		JsonPatchDocument<ApiOfficerCapabilitiesServerRequestModel> CreatePatch(ApiOfficerCapabilitiesServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f3293cd0d083abd718c747f9042d9005</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/