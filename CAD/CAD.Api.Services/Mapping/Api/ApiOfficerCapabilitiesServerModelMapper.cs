using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiOfficerCapabilitiesServerModelMapper : IApiOfficerCapabilitiesServerModelMapper
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
    <Hash>578b7220798b928d51209fe3f27feb7d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/