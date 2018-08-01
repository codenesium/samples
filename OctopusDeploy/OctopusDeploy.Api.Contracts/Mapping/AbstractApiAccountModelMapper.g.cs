using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiAccountModelMapper
	{
		public virtual ApiAccountResponseModel MapRequestToResponse(
			string id,
			ApiAccountRequestModel request)
		{
			var response = new ApiAccountResponseModel();
			response.SetProperties(id,
			                       request.AccountType,
			                       request.EnvironmentIds,
			                       request.JSON,
			                       request.Name,
			                       request.TenantIds,
			                       request.TenantTags);
			return response;
		}

		public virtual ApiAccountRequestModel MapResponseToRequest(
			ApiAccountResponseModel response)
		{
			var request = new ApiAccountRequestModel();
			request.SetProperties(
				response.AccountType,
				response.EnvironmentIds,
				response.JSON,
				response.Name,
				response.TenantIds,
				response.TenantTags);
			return request;
		}

		public JsonPatchDocument<ApiAccountRequestModel> CreatePatch(ApiAccountRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAccountRequestModel>();
			patch.Replace(x => x.AccountType, model.AccountType);
			patch.Replace(x => x.EnvironmentIds, model.EnvironmentIds);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.TenantIds, model.TenantIds);
			patch.Replace(x => x.TenantTags, model.TenantTags);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a31599cf7a392788d2d5a7f16087f986</Hash>
</Codenesium>*/