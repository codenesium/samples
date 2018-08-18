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
    <Hash>5887cea5013fc20a6b040f6cef50ceb6</Hash>
</Codenesium>*/