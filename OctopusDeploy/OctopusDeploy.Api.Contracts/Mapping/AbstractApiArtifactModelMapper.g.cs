using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiArtifactModelMapper
	{
		public virtual ApiArtifactResponseModel MapRequestToResponse(
			string id,
			ApiArtifactRequestModel request)
		{
			var response = new ApiArtifactResponseModel();
			response.SetProperties(id,
			                       request.Created,
			                       request.EnvironmentId,
			                       request.Filename,
			                       request.JSON,
			                       request.ProjectId,
			                       request.RelatedDocumentIds,
			                       request.TenantId);
			return response;
		}

		public virtual ApiArtifactRequestModel MapResponseToRequest(
			ApiArtifactResponseModel response)
		{
			var request = new ApiArtifactRequestModel();
			request.SetProperties(
				response.Created,
				response.EnvironmentId,
				response.Filename,
				response.JSON,
				response.ProjectId,
				response.RelatedDocumentIds,
				response.TenantId);
			return request;
		}

		public JsonPatchDocument<ApiArtifactRequestModel> CreatePatch(ApiArtifactRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiArtifactRequestModel>();
			patch.Replace(x => x.Created, model.Created);
			patch.Replace(x => x.EnvironmentId, model.EnvironmentId);
			patch.Replace(x => x.Filename, model.Filename);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.ProjectId, model.ProjectId);
			patch.Replace(x => x.RelatedDocumentIds, model.RelatedDocumentIds);
			patch.Replace(x => x.TenantId, model.TenantId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>114cb89c69205036b936369d599462ae</Hash>
</Codenesium>*/