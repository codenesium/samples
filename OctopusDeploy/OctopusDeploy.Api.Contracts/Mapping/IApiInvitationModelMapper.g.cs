using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiInvitationModelMapper
	{
		ApiInvitationResponseModel MapRequestToResponse(
			string id,
			ApiInvitationRequestModel request);

		ApiInvitationRequestModel MapResponseToRequest(
			ApiInvitationResponseModel response);

		JsonPatchDocument<ApiInvitationRequestModel> CreatePatch(ApiInvitationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>30ecfe223edec6733215e9a44b9668c0</Hash>
</Codenesium>*/