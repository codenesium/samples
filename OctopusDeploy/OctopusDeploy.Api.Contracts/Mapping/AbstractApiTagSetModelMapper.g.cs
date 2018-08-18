using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiTagSetModelMapper
	{
		public virtual ApiTagSetResponseModel MapRequestToResponse(
			string id,
			ApiTagSetRequestModel request)
		{
			var response = new ApiTagSetResponseModel();
			response.SetProperties(id,
			                       request.DataVersion,
			                       request.JSON,
			                       request.Name,
			                       request.SortOrder);
			return response;
		}

		public virtual ApiTagSetRequestModel MapResponseToRequest(
			ApiTagSetResponseModel response)
		{
			var request = new ApiTagSetRequestModel();
			request.SetProperties(
				response.DataVersion,
				response.JSON,
				response.Name,
				response.SortOrder);
			return request;
		}

		public JsonPatchDocument<ApiTagSetRequestModel> CreatePatch(ApiTagSetRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTagSetRequestModel>();
			patch.Replace(x => x.DataVersion, model.DataVersion);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.SortOrder, model.SortOrder);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>80d7478d6c75590b863cfa3591966cfa</Hash>
</Codenesium>*/