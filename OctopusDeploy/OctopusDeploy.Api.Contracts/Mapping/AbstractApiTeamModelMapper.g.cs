using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiTeamModelMapper
	{
		public virtual ApiTeamResponseModel MapRequestToResponse(
			string id,
			ApiTeamRequestModel request)
		{
			var response = new ApiTeamResponseModel();
			response.SetProperties(id,
			                       request.EnvironmentIds,
			                       request.JSON,
			                       request.MemberUserIds,
			                       request.Name,
			                       request.ProjectGroupIds,
			                       request.ProjectIds,
			                       request.TenantIds,
			                       request.TenantTags);
			return response;
		}

		public virtual ApiTeamRequestModel MapResponseToRequest(
			ApiTeamResponseModel response)
		{
			var request = new ApiTeamRequestModel();
			request.SetProperties(
				response.EnvironmentIds,
				response.JSON,
				response.MemberUserIds,
				response.Name,
				response.ProjectGroupIds,
				response.ProjectIds,
				response.TenantIds,
				response.TenantTags);
			return request;
		}

		public JsonPatchDocument<ApiTeamRequestModel> CreatePatch(ApiTeamRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeamRequestModel>();
			patch.Replace(x => x.EnvironmentIds, model.EnvironmentIds);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.MemberUserIds, model.MemberUserIds);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ProjectGroupIds, model.ProjectGroupIds);
			patch.Replace(x => x.ProjectIds, model.ProjectIds);
			patch.Replace(x => x.TenantIds, model.TenantIds);
			patch.Replace(x => x.TenantTags, model.TenantTags);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b98e161d2c2da5817955733dd9b46534</Hash>
</Codenesium>*/