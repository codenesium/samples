using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiSchemaBPersonServerModelMapper
	{
		public virtual ApiSchemaBPersonServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSchemaBPersonServerRequestModel request)
		{
			var response = new ApiSchemaBPersonServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSchemaBPersonServerRequestModel MapServerResponseToRequest(
			ApiSchemaBPersonServerResponseModel response)
		{
			var request = new ApiSchemaBPersonServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiSchemaBPersonClientRequestModel MapServerResponseToClientRequest(
			ApiSchemaBPersonServerResponseModel response)
		{
			var request = new ApiSchemaBPersonClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiSchemaBPersonServerRequestModel> CreatePatch(ApiSchemaBPersonServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSchemaBPersonServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>effd73906bb9c50f6a070ba1b6bd7f11</Hash>
</Codenesium>*/