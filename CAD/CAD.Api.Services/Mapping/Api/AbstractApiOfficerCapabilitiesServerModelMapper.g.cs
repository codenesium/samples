using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiOfficerCapabilitiesServerModelMapper
	{
		public virtual ApiOfficerCapabilitiesServerResponseModel MapServerRequestToResponse(
			int capabilityId,
			ApiOfficerCapabilitiesServerRequestModel request)
		{
			var response = new ApiOfficerCapabilitiesServerResponseModel();
			response.SetProperties(capabilityId,
			                       request.OfficerId);
			return response;
		}

		public virtual ApiOfficerCapabilitiesServerRequestModel MapServerResponseToRequest(
			ApiOfficerCapabilitiesServerResponseModel response)
		{
			var request = new ApiOfficerCapabilitiesServerRequestModel();
			request.SetProperties(
				response.OfficerId);
			return request;
		}

		public virtual ApiOfficerCapabilitiesClientRequestModel MapServerResponseToClientRequest(
			ApiOfficerCapabilitiesServerResponseModel response)
		{
			var request = new ApiOfficerCapabilitiesClientRequestModel();
			request.SetProperties(
				response.OfficerId);
			return request;
		}

		public JsonPatchDocument<ApiOfficerCapabilitiesServerRequestModel> CreatePatch(ApiOfficerCapabilitiesServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiOfficerCapabilitiesServerRequestModel>();
			patch.Replace(x => x.OfficerId, model.OfficerId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e498f310b2ebcd30c31bc1bc0248c1de</Hash>
</Codenesium>*/