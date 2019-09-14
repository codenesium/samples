using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiCallDispositionServerModelMapper : IApiCallDispositionServerModelMapper
	{
		public virtual ApiCallDispositionServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallDispositionServerRequestModel request)
		{
			var response = new ApiCallDispositionServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiCallDispositionServerRequestModel MapServerResponseToRequest(
			ApiCallDispositionServerResponseModel response)
		{
			var request = new ApiCallDispositionServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiCallDispositionClientRequestModel MapServerResponseToClientRequest(
			ApiCallDispositionServerResponseModel response)
		{
			var request = new ApiCallDispositionClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCallDispositionServerRequestModel> CreatePatch(ApiCallDispositionServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCallDispositionServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>864d4cccb2c87787c73a5f923f747486</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/