using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>4f1585a394e269de4d48ade88ecd9f46</Hash>
</Codenesium>*/