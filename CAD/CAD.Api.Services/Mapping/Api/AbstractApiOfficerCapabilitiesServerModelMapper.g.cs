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
			int id,
			ApiOfficerCapabilitiesServerRequestModel request)
		{
			var response = new ApiOfficerCapabilitiesServerResponseModel();
			response.SetProperties(id,
			                       request.CapabilityId,
			                       request.OfficerId);
			return response;
		}

		public virtual ApiOfficerCapabilitiesServerRequestModel MapServerResponseToRequest(
			ApiOfficerCapabilitiesServerResponseModel response)
		{
			var request = new ApiOfficerCapabilitiesServerRequestModel();
			request.SetProperties(
				response.CapabilityId,
				response.OfficerId);
			return request;
		}

		public virtual ApiOfficerCapabilitiesClientRequestModel MapServerResponseToClientRequest(
			ApiOfficerCapabilitiesServerResponseModel response)
		{
			var request = new ApiOfficerCapabilitiesClientRequestModel();
			request.SetProperties(
				response.CapabilityId,
				response.OfficerId);
			return request;
		}

		public JsonPatchDocument<ApiOfficerCapabilitiesServerRequestModel> CreatePatch(ApiOfficerCapabilitiesServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiOfficerCapabilitiesServerRequestModel>();
			patch.Replace(x => x.CapabilityId, model.CapabilityId);
			patch.Replace(x => x.OfficerId, model.OfficerId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>187e590c5e61b6c48d53e35aaa62b68c</Hash>
</Codenesium>*/