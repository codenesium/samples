using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiSchemaVersionsModelMapper
	{
		public virtual ApiSchemaVersionsResponseModel MapRequestToResponse(
			int id,
			ApiSchemaVersionsRequestModel request)
		{
			var response = new ApiSchemaVersionsResponseModel();
			response.SetProperties(id,
			                       request.Applied,
			                       request.ScriptName);
			return response;
		}

		public virtual ApiSchemaVersionsRequestModel MapResponseToRequest(
			ApiSchemaVersionsResponseModel response)
		{
			var request = new ApiSchemaVersionsRequestModel();
			request.SetProperties(
				response.Applied,
				response.ScriptName);
			return request;
		}

		public JsonPatchDocument<ApiSchemaVersionsRequestModel> CreatePatch(ApiSchemaVersionsRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSchemaVersionsRequestModel>();
			patch.Replace(x => x.Applied, model.Applied);
			patch.Replace(x => x.ScriptName, model.ScriptName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>343999ead5aa535a032d0c00984e23cb</Hash>
</Codenesium>*/