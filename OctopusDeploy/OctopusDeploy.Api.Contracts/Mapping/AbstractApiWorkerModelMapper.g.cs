using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiWorkerModelMapper
	{
		public virtual ApiWorkerResponseModel MapRequestToResponse(
			string id,
			ApiWorkerRequestModel request)
		{
			var response = new ApiWorkerResponseModel();
			response.SetProperties(id,
			                       request.CommunicationStyle,
			                       request.Fingerprint,
			                       request.IsDisabled,
			                       request.JSON,
			                       request.MachinePolicyId,
			                       request.Name,
			                       request.RelatedDocumentIds,
			                       request.Thumbprint,
			                       request.WorkerPoolIds);
			return response;
		}

		public virtual ApiWorkerRequestModel MapResponseToRequest(
			ApiWorkerResponseModel response)
		{
			var request = new ApiWorkerRequestModel();
			request.SetProperties(
				response.CommunicationStyle,
				response.Fingerprint,
				response.IsDisabled,
				response.JSON,
				response.MachinePolicyId,
				response.Name,
				response.RelatedDocumentIds,
				response.Thumbprint,
				response.WorkerPoolIds);
			return request;
		}

		public JsonPatchDocument<ApiWorkerRequestModel> CreatePatch(ApiWorkerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiWorkerRequestModel>();
			patch.Replace(x => x.CommunicationStyle, model.CommunicationStyle);
			patch.Replace(x => x.Fingerprint, model.Fingerprint);
			patch.Replace(x => x.IsDisabled, model.IsDisabled);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.MachinePolicyId, model.MachinePolicyId);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.RelatedDocumentIds, model.RelatedDocumentIds);
			patch.Replace(x => x.Thumbprint, model.Thumbprint);
			patch.Replace(x => x.WorkerPoolIds, model.WorkerPoolIds);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>98b52d1b4388ff5faf04598033ec8062</Hash>
</Codenesium>*/