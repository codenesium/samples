using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiOfficerRefCapabilityServerModelMapper
	{
		public virtual ApiOfficerRefCapabilityServerResponseModel MapServerRequestToResponse(
			int id,
			ApiOfficerRefCapabilityServerRequestModel request)
		{
			var response = new ApiOfficerRefCapabilityServerResponseModel();
			response.SetProperties(id,
			                       request.CapabilityId,
			                       request.OfficerId);
			return response;
		}

		public virtual ApiOfficerRefCapabilityServerRequestModel MapServerResponseToRequest(
			ApiOfficerRefCapabilityServerResponseModel response)
		{
			var request = new ApiOfficerRefCapabilityServerRequestModel();
			request.SetProperties(
				response.CapabilityId,
				response.OfficerId);
			return request;
		}

		public virtual ApiOfficerRefCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiOfficerRefCapabilityServerResponseModel response)
		{
			var request = new ApiOfficerRefCapabilityClientRequestModel();
			request.SetProperties(
				response.CapabilityId,
				response.OfficerId);
			return request;
		}

		public JsonPatchDocument<ApiOfficerRefCapabilityServerRequestModel> CreatePatch(ApiOfficerRefCapabilityServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiOfficerRefCapabilityServerRequestModel>();
			patch.Replace(x => x.CapabilityId, model.CapabilityId);
			patch.Replace(x => x.OfficerId, model.OfficerId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>060e48cee084e813a78b215eeaa65729</Hash>
</Codenesium>*/