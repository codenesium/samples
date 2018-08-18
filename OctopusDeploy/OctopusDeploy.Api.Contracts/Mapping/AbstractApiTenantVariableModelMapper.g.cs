using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiTenantVariableModelMapper
	{
		public virtual ApiTenantVariableResponseModel MapRequestToResponse(
			string id,
			ApiTenantVariableRequestModel request)
		{
			var response = new ApiTenantVariableResponseModel();
			response.SetProperties(id,
			                       request.EnvironmentId,
			                       request.JSON,
			                       request.OwnerId,
			                       request.RelatedDocumentId,
			                       request.TenantId,
			                       request.VariableTemplateId);
			return response;
		}

		public virtual ApiTenantVariableRequestModel MapResponseToRequest(
			ApiTenantVariableResponseModel response)
		{
			var request = new ApiTenantVariableRequestModel();
			request.SetProperties(
				response.EnvironmentId,
				response.JSON,
				response.OwnerId,
				response.RelatedDocumentId,
				response.TenantId,
				response.VariableTemplateId);
			return request;
		}

		public JsonPatchDocument<ApiTenantVariableRequestModel> CreatePatch(ApiTenantVariableRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTenantVariableRequestModel>();
			patch.Replace(x => x.EnvironmentId, model.EnvironmentId);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.OwnerId, model.OwnerId);
			patch.Replace(x => x.RelatedDocumentId, model.RelatedDocumentId);
			patch.Replace(x => x.TenantId, model.TenantId);
			patch.Replace(x => x.VariableTemplateId, model.VariableTemplateId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>37db9db10354d34f857ec3126482f765</Hash>
</Codenesium>*/