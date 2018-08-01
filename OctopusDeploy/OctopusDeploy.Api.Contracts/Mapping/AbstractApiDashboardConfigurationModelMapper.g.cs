using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiDashboardConfigurationModelMapper
	{
		public virtual ApiDashboardConfigurationResponseModel MapRequestToResponse(
			string id,
			ApiDashboardConfigurationRequestModel request)
		{
			var response = new ApiDashboardConfigurationResponseModel();
			response.SetProperties(id,
			                       request.IncludedEnvironmentIds,
			                       request.IncludedProjectIds,
			                       request.IncludedTenantIds,
			                       request.IncludedTenantTags,
			                       request.JSON);
			return response;
		}

		public virtual ApiDashboardConfigurationRequestModel MapResponseToRequest(
			ApiDashboardConfigurationResponseModel response)
		{
			var request = new ApiDashboardConfigurationRequestModel();
			request.SetProperties(
				response.IncludedEnvironmentIds,
				response.IncludedProjectIds,
				response.IncludedTenantIds,
				response.IncludedTenantTags,
				response.JSON);
			return request;
		}

		public JsonPatchDocument<ApiDashboardConfigurationRequestModel> CreatePatch(ApiDashboardConfigurationRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDashboardConfigurationRequestModel>();
			patch.Replace(x => x.IncludedEnvironmentIds, model.IncludedEnvironmentIds);
			patch.Replace(x => x.IncludedProjectIds, model.IncludedProjectIds);
			patch.Replace(x => x.IncludedTenantIds, model.IncludedTenantIds);
			patch.Replace(x => x.IncludedTenantTags, model.IncludedTenantTags);
			patch.Replace(x => x.JSON, model.JSON);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>481e92f6518feb1f79bf9c099fd8a93c</Hash>
</Codenesium>*/