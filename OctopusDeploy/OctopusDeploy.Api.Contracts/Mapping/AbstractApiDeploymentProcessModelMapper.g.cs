using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiDeploymentProcessModelMapper
	{
		public virtual ApiDeploymentProcessResponseModel MapRequestToResponse(
			string id,
			ApiDeploymentProcessRequestModel request)
		{
			var response = new ApiDeploymentProcessResponseModel();
			response.SetProperties(id,
			                       request.IsFrozen,
			                       request.JSON,
			                       request.OwnerId,
			                       request.RelatedDocumentIds,
			                       request.Version);
			return response;
		}

		public virtual ApiDeploymentProcessRequestModel MapResponseToRequest(
			ApiDeploymentProcessResponseModel response)
		{
			var request = new ApiDeploymentProcessRequestModel();
			request.SetProperties(
				response.IsFrozen,
				response.JSON,
				response.OwnerId,
				response.RelatedDocumentIds,
				response.Version);
			return request;
		}

		public JsonPatchDocument<ApiDeploymentProcessRequestModel> CreatePatch(ApiDeploymentProcessRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDeploymentProcessRequestModel>();
			patch.Replace(x => x.IsFrozen, model.IsFrozen);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.OwnerId, model.OwnerId);
			patch.Replace(x => x.RelatedDocumentIds, model.RelatedDocumentIds);
			patch.Replace(x => x.Version, model.Version);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b07f8ebb0c92b9e9ed9570cd225a3823</Hash>
</Codenesium>*/