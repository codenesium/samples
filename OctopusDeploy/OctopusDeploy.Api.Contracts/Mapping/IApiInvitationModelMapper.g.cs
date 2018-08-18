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
    <Hash>392391dca19ac659ad563c1e84f2f292</Hash>
</Codenesium>*/