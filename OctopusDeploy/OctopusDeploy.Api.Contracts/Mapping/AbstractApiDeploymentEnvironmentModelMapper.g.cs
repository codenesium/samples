using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiDeploymentEnvironmentModelMapper
	{
		public virtual ApiDeploymentEnvironmentResponseModel MapRequestToResponse(
			string id,
			ApiDeploymentEnvironmentRequestModel request)
		{
			var response = new ApiDeploymentEnvironmentResponseModel();
			response.SetProperties(id,
			                       request.DataVersion,
			                       request.JSON,
			                       request.Name,
			                       request.SortOrder);
			return response;
		}

		public virtual ApiDeploymentEnvironmentRequestModel MapResponseToRequest(
			ApiDeploymentEnvironmentResponseModel response)
		{
			var request = new ApiDeploymentEnvironmentRequestModel();
			request.SetProperties(
				response.DataVersion,
				response.JSON,
				response.Name,
				response.SortOrder);
			return request;
		}

		public JsonPatchDocument<ApiDeploymentEnvironmentRequestModel> CreatePatch(ApiDeploymentEnvironmentRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDeploymentEnvironmentRequestModel>();
			patch.Replace(x => x.DataVersion, model.DataVersion);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.SortOrder, model.SortOrder);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>4761962e1aee1eb7c109762150b78643</Hash>
</Codenesium>*/