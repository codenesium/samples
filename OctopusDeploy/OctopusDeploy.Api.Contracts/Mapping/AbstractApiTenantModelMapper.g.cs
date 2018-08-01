using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiTenantModelMapper
	{
		public virtual ApiTenantResponseModel MapRequestToResponse(
			string id,
			ApiTenantRequestModel request)
		{
			var response = new ApiTenantResponseModel();
			response.SetProperties(id,
			                       request.DataVersion,
			                       request.JSON,
			                       request.Name,
			                       request.ProjectIds,
			                       request.TenantTags);
			return response;
		}

		public virtual ApiTenantRequestModel MapResponseToRequest(
			ApiTenantResponseModel response)
		{
			var request = new ApiTenantRequestModel();
			request.SetProperties(
				response.DataVersion,
				response.JSON,
				response.Name,
				response.ProjectIds,
				response.TenantTags);
			return request;
		}

		public JsonPatchDocument<ApiTenantRequestModel> CreatePatch(ApiTenantRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTenantRequestModel>();
			patch.Replace(x => x.DataVersion, model.DataVersion);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ProjectIds, model.ProjectIds);
			patch.Replace(x => x.TenantTags, model.TenantTags);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>258ea721df3a3e07cb72659fb9aacc63</Hash>
</Codenesium>*/