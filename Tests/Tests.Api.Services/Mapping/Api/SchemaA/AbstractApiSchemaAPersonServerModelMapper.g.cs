using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiSchemaAPersonServerModelMapper
	{
		public virtual ApiSchemaAPersonServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSchemaAPersonServerRequestModel request)
		{
			var response = new ApiSchemaAPersonServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSchemaAPersonServerRequestModel MapServerResponseToRequest(
			ApiSchemaAPersonServerResponseModel response)
		{
			var request = new ApiSchemaAPersonServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiSchemaAPersonClientRequestModel MapServerResponseToClientRequest(
			ApiSchemaAPersonServerResponseModel response)
		{
			var request = new ApiSchemaAPersonClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiSchemaAPersonServerRequestModel> CreatePatch(ApiSchemaAPersonServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSchemaAPersonServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e9eafe465afef4d21358ac646ae273a3</Hash>
</Codenesium>*/