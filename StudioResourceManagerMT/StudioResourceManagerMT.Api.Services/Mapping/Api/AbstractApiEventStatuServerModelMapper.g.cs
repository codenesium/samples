using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiEventStatuServerModelMapper
	{
		public virtual ApiEventStatuServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventStatuServerRequestModel request)
		{
			var response = new ApiEventStatuServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiEventStatuServerRequestModel MapServerResponseToRequest(
			ApiEventStatuServerResponseModel response)
		{
			var request = new ApiEventStatuServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiEventStatuClientRequestModel MapServerResponseToClientRequest(
			ApiEventStatuServerResponseModel response)
		{
			var request = new ApiEventStatuClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiEventStatuServerRequestModel> CreatePatch(ApiEventStatuServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventStatuServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8fe06d24353b3df90e00d59d88b8764c</Hash>
</Codenesium>*/