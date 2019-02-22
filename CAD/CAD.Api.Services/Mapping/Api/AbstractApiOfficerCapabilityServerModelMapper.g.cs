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
			int id,
			ApiOfficerCapabilityServerRequestModel request)
		{
			var response = new ApiOfficerCapabilityServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiOfficerCapabilityServerRequestModel MapServerResponseToRequest(
			ApiOfficerCapabilityServerResponseModel response)
		{
			var request = new ApiOfficerCapabilityServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiOfficerCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiOfficerCapabilityServerResponseModel response)
		{
			var request = new ApiOfficerCapabilityClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiOfficerCapabilityServerRequestModel> CreatePatch(ApiOfficerCapabilityServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiOfficerCapabilityServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f3f2028fa6a56c68c2ae29c8b66f2c9d</Hash>
</Codenesium>*/