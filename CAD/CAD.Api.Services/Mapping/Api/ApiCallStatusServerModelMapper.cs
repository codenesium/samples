using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiCallStatusServerModelMapper : IApiCallStatusServerModelMapper
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
    <Hash>326d6b47b507f3f1a912c89dcdde6464</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/