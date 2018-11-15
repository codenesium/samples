using ESPIOTNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractApiDeviceServerModelMapper
	{
		public virtual ApiDeviceServerResponseModel MapServerRequestToResponse(
			int id,
			ApiDeviceServerRequestModel request)
		{
			var response = new ApiDeviceServerResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.PublicId);
			return response;
		}

		public virtual ApiDeviceServerRequestModel MapServerResponseToRequest(
			ApiDeviceServerResponseModel response)
		{
			var request = new ApiDeviceServerRequestModel();
			request.SetProperties(
				response.Name,
				response.PublicId);
			return request;
		}

		public virtual ApiDeviceClientRequestModel MapServerResponseToClientRequest(
			ApiDeviceServerResponseModel response)
		{
			var request = new ApiDeviceClientRequestModel();
			request.SetProperties(
				response.Name,
				response.PublicId);
			return request;
		}

		public JsonPatchDocument<ApiDeviceServerRequestModel> CreatePatch(ApiDeviceServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDeviceServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.PublicId, model.PublicId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d59a58b47a82717a2793e7ba977ebab8</Hash>
</Codenesium>*/