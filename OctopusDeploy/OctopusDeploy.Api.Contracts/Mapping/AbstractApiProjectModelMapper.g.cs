using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiProjectModelMapper
	{
		public virtual ApiProjectResponseModel MapRequestToResponse(
			string id,
			ApiProjectRequestModel request)
		{
			var response = new ApiProjectResponseModel();
			response.SetProperties(id,
			                       request.AutoCreateRelease,
			                       request.DataVersion,
			                       request.DeploymentProcessId,
			                       request.DiscreteChannelRelease,
			                       request.IncludedLibraryVariableSetIds,
			                       request.IsDisabled,
			                       request.JSON,
			                       request.LifecycleId,
			                       request.Name,
			                       request.ProjectGroupId,
			                       request.Slug,
			                       request.VariableSetId);
			return response;
		}

		public virtual ApiProjectRequestModel MapResponseToRequest(
			ApiProjectResponseModel response)
		{
			var request = new ApiProjectRequestModel();
			request.SetProperties(
				response.AutoCreateRelease,
				response.DataVersion,
				response.DeploymentProcessId,
				response.DiscreteChannelRelease,
				response.IncludedLibraryVariableSetIds,
				response.IsDisabled,
				response.JSON,
				response.LifecycleId,
				response.Name,
				response.ProjectGroupId,
				response.Slug,
				response.VariableSetId);
			return request;
		}

		public JsonPatchDocument<ApiProjectRequestModel> CreatePatch(ApiProjectRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProjectRequestModel>();
			patch.Replace(x => x.AutoCreateRelease, model.AutoCreateRelease);
			patch.Replace(x => x.DataVersion, model.DataVersion);
			patch.Replace(x => x.DeploymentProcessId, model.DeploymentProcessId);
			patch.Replace(x => x.DiscreteChannelRelease, model.DiscreteChannelRelease);
			patch.Replace(x => x.IncludedLibraryVariableSetIds, model.IncludedLibraryVariableSetIds);
			patch.Replace(x => x.IsDisabled, model.IsDisabled);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.LifecycleId, model.LifecycleId);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ProjectGroupId, model.ProjectGroupId);
			patch.Replace(x => x.Slug, model.Slug);
			patch.Replace(x => x.VariableSetId, model.VariableSetId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>10adc5bd06cfb2ee14773fb25db46150</Hash>
</Codenesium>*/