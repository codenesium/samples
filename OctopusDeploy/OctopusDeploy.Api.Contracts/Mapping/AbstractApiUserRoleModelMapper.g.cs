using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiUserRoleModelMapper
	{
		public virtual ApiUserRoleResponseModel MapRequestToResponse(
			string id,
			ApiUserRoleRequestModel request)
		{
			var response = new ApiUserRoleResponseModel();
			response.SetProperties(id,
			                       request.JSON,
			                       request.Name);
			return response;
		}

		public virtual ApiUserRoleRequestModel MapResponseToRequest(
			ApiUserRoleResponseModel response)
		{
			var request = new ApiUserRoleRequestModel();
			request.SetProperties(
				response.JSON,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiUserRoleRequestModel> CreatePatch(ApiUserRoleRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUserRoleRequestModel>();
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>2d6c172b6ca2b9e10861d5d3cf4ba874</Hash>
</Codenesium>*/