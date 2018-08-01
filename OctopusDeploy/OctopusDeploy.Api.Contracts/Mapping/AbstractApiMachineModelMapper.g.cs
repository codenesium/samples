using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiMachineModelMapper
	{
		public virtual ApiMachineResponseModel MapRequestToResponse(
			string id,
			ApiMachineRequestModel request)
		{
			var response = new ApiMachineResponseModel();
			response.SetProperties(id,
			                       request.CommunicationStyle,
			                       request.EnvironmentIds,
			                       request.Fingerprint,
			                       request.IsDisabled,
			                       request.JSON,
			                       request.MachinePolicyId,
			                       request.Name,
			                       request.RelatedDocumentIds,
			                       request.Roles,
			                       request.TenantIds,
			                       request.TenantTags,
			                       request.Thumbprint);
			return response;
		}

		public virtual ApiMachineRequestModel MapResponseToRequest(
			ApiMachineResponseModel response)
		{
			var request = new ApiMachineRequestModel();
			request.SetProperties(
				response.CommunicationStyle,
				response.EnvironmentIds,
				response.Fingerprint,
				response.IsDisabled,
				response.JSON,
				response.MachinePolicyId,
				response.Name,
				response.RelatedDocumentIds,
				response.Roles,
				response.TenantIds,
				response.TenantTags,
				response.Thumbprint);
			return request;
		}

		public JsonPatchDocument<ApiMachineRequestModel> CreatePatch(ApiMachineRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiMachineRequestModel>();
			patch.Replace(x => x.CommunicationStyle, model.CommunicationStyle);
			patch.Replace(x => x.EnvironmentIds, model.EnvironmentIds);
			patch.Replace(x => x.Fingerprint, model.Fingerprint);
			patch.Replace(x => x.IsDisabled, model.IsDisabled);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.MachinePolicyId, model.MachinePolicyId);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.RelatedDocumentIds, model.RelatedDocumentIds);
			patch.Replace(x => x.Roles, model.Roles);
			patch.Replace(x => x.TenantIds, model.TenantIds);
			patch.Replace(x => x.TenantTags, model.TenantTags);
			patch.Replace(x => x.Thumbprint, model.Thumbprint);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>87853be67f1e7cdbfa16aa0ac5ffdb28</Hash>
</Codenesium>*/