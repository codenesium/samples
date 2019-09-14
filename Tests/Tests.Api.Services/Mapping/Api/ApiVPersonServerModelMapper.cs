using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public class ApiVPersonServerModelMapper : IApiVPersonServerModelMapper
	{
		public virtual ApiVPersonServerResponseModel MapServerRequestToResponse(
			int personId,
			ApiVPersonServerRequestModel request)
		{
			var response = new ApiVPersonServerResponseModel();
			response.SetProperties(personId,
			                       request.PersonName);
			return response;
		}

		public virtual ApiVPersonServerRequestModel MapServerResponseToRequest(
			ApiVPersonServerResponseModel response)
		{
			var request = new ApiVPersonServerRequestModel();
			request.SetProperties(
				response.PersonName);
			return request;
		}

		public virtual ApiVPersonClientRequestModel MapServerResponseToClientRequest(
			ApiVPersonServerResponseModel response)
		{
			var request = new ApiVPersonClientRequestModel();
			request.SetProperties(
				response.PersonName);
			return request;
		}

		public JsonPatchDocument<ApiVPersonServerRequestModel> CreatePatch(ApiVPersonServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVPersonServerRequestModel>();
			patch.Replace(x => x.PersonName, model.PersonName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>6b3ba10a05d5e10a94d48c57f307bb91</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/