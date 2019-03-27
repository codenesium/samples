using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiCallStatusServerModelMapper
	{
		public virtual ApiCallStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallStatusServerRequestModel request)
		{
			var response = new ApiCallStatusServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiCallStatusServerRequestModel MapServerResponseToRequest(
			ApiCallStatusServerResponseModel response)
		{
			var request = new ApiCallStatusServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiCallStatusClientRequestModel MapServerResponseToClientRequest(
			ApiCallStatusServerResponseModel response)
		{
			var request = new ApiCallStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCallStatusServerRequestModel> CreatePatch(ApiCallStatusServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCallStatusServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b71daec143e9d1f0194d25576d347942</Hash>
</Codenesium>*/