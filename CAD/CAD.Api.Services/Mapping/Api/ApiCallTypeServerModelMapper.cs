using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiCallTypeServerModelMapper : IApiCallTypeServerModelMapper
	{
		public virtual ApiCallTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallTypeServerRequestModel request)
		{
			var response = new ApiCallTypeServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiCallTypeServerRequestModel MapServerResponseToRequest(
			ApiCallTypeServerResponseModel response)
		{
			var request = new ApiCallTypeServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiCallTypeClientRequestModel MapServerResponseToClientRequest(
			ApiCallTypeServerResponseModel response)
		{
			var request = new ApiCallTypeClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCallTypeServerRequestModel> CreatePatch(ApiCallTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCallTypeServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>830e69d152d3cb4ca8cdde7af2cfb1e7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/