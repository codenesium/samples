using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCultureServerModelMapper
	{
		public virtual ApiCultureServerResponseModel MapServerRequestToResponse(
			string cultureID,
			ApiCultureServerRequestModel request)
		{
			var response = new ApiCultureServerResponseModel();
			response.SetProperties(cultureID,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiCultureServerRequestModel MapServerResponseToRequest(
			ApiCultureServerResponseModel response)
		{
			var request = new ApiCultureServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public virtual ApiCultureClientRequestModel MapServerResponseToClientRequest(
			ApiCultureServerResponseModel response)
		{
			var request = new ApiCultureClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCultureServerRequestModel> CreatePatch(ApiCultureServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCultureServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8d8f98fe2125dd7c2563b6f39ce0c294</Hash>
</Codenesium>*/