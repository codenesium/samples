using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiInvitationModelMapper
	{
		public virtual ApiInvitationResponseModel MapRequestToResponse(
			string id,
			ApiInvitationRequestModel request)
		{
			var response = new ApiInvitationResponseModel();
			response.SetProperties(id,
			                       request.InvitationCode,
			                       request.JSON);
			return response;
		}

		public virtual ApiInvitationRequestModel MapResponseToRequest(
			ApiInvitationResponseModel response)
		{
			var request = new ApiInvitationRequestModel();
			request.SetProperties(
				response.InvitationCode,
				response.JSON);
			return request;
		}

		public JsonPatchDocument<ApiInvitationRequestModel> CreatePatch(ApiInvitationRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiInvitationRequestModel>();
			patch.Replace(x => x.InvitationCode, model.InvitationCode);
			patch.Replace(x => x.JSON, model.JSON);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c180b0e028f476217fb4c5e95333e703</Hash>
</Codenesium>*/