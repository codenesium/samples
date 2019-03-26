using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiOfficerCapabilityServerModelMapper
	{
		public virtual ApiOfficerCapabilityServerResponseModel MapServerRequestToResponse(
			int capabilityId,
			ApiOfficerCapabilityServerRequestModel request)
		{
			var response = new ApiOfficerCapabilityServerResponseModel();
			response.SetProperties(capabilityId,
			                       request.OfficerId);
			return response;
		}

		public virtual ApiOfficerCapabilityServerRequestModel MapServerResponseToRequest(
			ApiOfficerCapabilityServerResponseModel response)
		{
			var request = new ApiOfficerCapabilityServerRequestModel();
			request.SetProperties(
				response.OfficerId);
			return request;
		}

		public virtual ApiOfficerCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiOfficerCapabilityServerResponseModel response)
		{
			var request = new ApiOfficerCapabilityClientRequestModel();
			request.SetProperties(
				response.OfficerId);
			return request;
		}

		public JsonPatchDocument<ApiOfficerCapabilityServerRequestModel> CreatePatch(ApiOfficerCapabilityServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiOfficerCapabilityServerRequestModel>();
			patch.Replace(x => x.OfficerId, model.OfficerId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e0e65c5bc54e5709e99c68cab1a3544c</Hash>
</Codenesium>*/