using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiLibraryVariableSetModelMapper
	{
		public virtual ApiLibraryVariableSetResponseModel MapRequestToResponse(
			string id,
			ApiLibraryVariableSetRequestModel request)
		{
			var response = new ApiLibraryVariableSetResponseModel();
			response.SetProperties(id,
			                       request.ContentType,
			                       request.JSON,
			                       request.Name,
			                       request.VariableSetId);
			return response;
		}

		public virtual ApiLibraryVariableSetRequestModel MapResponseToRequest(
			ApiLibraryVariableSetResponseModel response)
		{
			var request = new ApiLibraryVariableSetRequestModel();
			request.SetProperties(
				response.ContentType,
				response.JSON,
				response.Name,
				response.VariableSetId);
			return request;
		}

		public JsonPatchDocument<ApiLibraryVariableSetRequestModel> CreatePatch(ApiLibraryVariableSetRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLibraryVariableSetRequestModel>();
			patch.Replace(x => x.ContentType, model.ContentType);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.VariableSetId, model.VariableSetId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>67aabf2588ef2fba01d7de0e1fdc08ae</Hash>
</Codenesium>*/