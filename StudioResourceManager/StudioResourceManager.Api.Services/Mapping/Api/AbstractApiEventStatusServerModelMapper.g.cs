using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiEventStatusServerModelMapper
	{
		public virtual ApiEventStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventStatusServerRequestModel request)
		{
			var response = new ApiEventStatusServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiEventStatusServerRequestModel MapServerResponseToRequest(
			ApiEventStatusServerResponseModel response)
		{
			var request = new ApiEventStatusServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiEventStatusClientRequestModel MapServerResponseToClientRequest(
			ApiEventStatusServerResponseModel response)
		{
			var request = new ApiEventStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiEventStatusServerRequestModel> CreatePatch(ApiEventStatusServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventStatusServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a5c39eab2798e34f3107200c28e03881</Hash>
</Codenesium>*/