using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiOctopusServerNodeModelMapper
	{
		public virtual ApiOctopusServerNodeResponseModel MapRequestToResponse(
			string id,
			ApiOctopusServerNodeRequestModel request)
		{
			var response = new ApiOctopusServerNodeResponseModel();
			response.SetProperties(id,
			                       request.IsInMaintenanceMode,
			                       request.JSON,
			                       request.LastSeen,
			                       request.MaxConcurrentTasks,
			                       request.Name,
			                       request.Rank);
			return response;
		}

		public virtual ApiOctopusServerNodeRequestModel MapResponseToRequest(
			ApiOctopusServerNodeResponseModel response)
		{
			var request = new ApiOctopusServerNodeRequestModel();
			request.SetProperties(
				response.IsInMaintenanceMode,
				response.JSON,
				response.LastSeen,
				response.MaxConcurrentTasks,
				response.Name,
				response.Rank);
			return request;
		}

		public JsonPatchDocument<ApiOctopusServerNodeRequestModel> CreatePatch(ApiOctopusServerNodeRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiOctopusServerNodeRequestModel>();
			patch.Replace(x => x.IsInMaintenanceMode, model.IsInMaintenanceMode);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.LastSeen, model.LastSeen);
			patch.Replace(x => x.MaxConcurrentTasks, model.MaxConcurrentTasks);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Rank, model.Rank);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>26f3446e1f09216551284cae132ebb32</Hash>
</Codenesium>*/