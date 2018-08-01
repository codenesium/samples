using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public abstract class AbstractApiSchemaAPersonModelMapper
	{
		public virtual ApiSchemaAPersonResponseModel MapRequestToResponse(
			int id,
			ApiSchemaAPersonRequestModel request)
		{
			var response = new ApiSchemaAPersonResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSchemaAPersonRequestModel MapResponseToRequest(
			ApiSchemaAPersonResponseModel response)
		{
			var request = new ApiSchemaAPersonRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiSchemaAPersonRequestModel> CreatePatch(ApiSchemaAPersonRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSchemaAPersonRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>33febb8d59d45dff6c9cd0f01744ba98</Hash>
</Codenesium>*/