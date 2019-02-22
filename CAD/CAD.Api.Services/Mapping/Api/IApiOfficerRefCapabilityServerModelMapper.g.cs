using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiOfficerRefCapabilityServerModelMapper
	{
		ApiOfficerRefCapabilityServerResponseModel MapServerRequestToResponse(
			int id,
			ApiOfficerRefCapabilityServerRequestModel request);

		ApiOfficerRefCapabilityServerRequestModel MapServerResponseToRequest(
			ApiOfficerRefCapabilityServerResponseModel response);

		ApiOfficerRefCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiOfficerRefCapabilityServerResponseModel response);

		JsonPatchDocument<ApiOfficerRefCapabilityServerRequestModel> CreatePatch(ApiOfficerRefCapabilityServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>64236b091d40dc61c6cfd1fc31d87d33</Hash>
</Codenesium>*/