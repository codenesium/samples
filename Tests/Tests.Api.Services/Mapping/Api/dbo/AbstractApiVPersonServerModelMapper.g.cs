using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiVPersonServerModelMapper
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
    <Hash>7b1d277d315ccd12c4db41b6fd5b9a2f</Hash>
</Codenesium>*/