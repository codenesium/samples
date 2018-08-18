using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiWorkerTaskLeaseModelMapper
	{
		public virtual ApiWorkerTaskLeaseResponseModel MapRequestToResponse(
			string id,
			ApiWorkerTaskLeaseRequestModel request)
		{
			var response = new ApiWorkerTaskLeaseResponseModel();
			response.SetProperties(id,
			                       request.Exclusive,
			                       request.JSON,
			                       request.Name,
			                       request.TaskId,
			                       request.WorkerId);
			return response;
		}

		public virtual ApiWorkerTaskLeaseRequestModel MapResponseToRequest(
			ApiWorkerTaskLeaseResponseModel response)
		{
			var request = new ApiWorkerTaskLeaseRequestModel();
			request.SetProperties(
				response.Exclusive,
				response.JSON,
				response.Name,
				response.TaskId,
				response.WorkerId);
			return request;
		}

		public JsonPatchDocument<ApiWorkerTaskLeaseRequestModel> CreatePatch(ApiWorkerTaskLeaseRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiWorkerTaskLeaseRequestModel>();
			patch.Replace(x => x.Exclusive, model.Exclusive);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.TaskId, model.TaskId);
			patch.Replace(x => x.WorkerId, model.WorkerId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7e240dc502fe8771fe21891cc37ea6b5</Hash>
</Codenesium>*/