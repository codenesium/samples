using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiInvitationModelMapper
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
    <Hash>c39ba121cf2bf203cc802580ce03fdab</Hash>
</Codenesium>*/