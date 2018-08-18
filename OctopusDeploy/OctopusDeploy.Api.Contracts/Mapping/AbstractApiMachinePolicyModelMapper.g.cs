using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiMachinePolicyModelMapper
	{
		public virtual ApiMachinePolicyResponseModel MapRequestToResponse(
			string id,
			ApiMachinePolicyRequestModel request)
		{
			var response = new ApiMachinePolicyResponseModel();
			response.SetProperties(id,
			                       request.IsDefault,
			                       request.JSON,
			                       request.Name);
			return response;
		}

		public virtual ApiMachinePolicyRequestModel MapResponseToRequest(
			ApiMachinePolicyResponseModel response)
		{
			var request = new ApiMachinePolicyRequestModel();
			request.SetProperties(
				response.IsDefault,
				response.JSON,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiMachinePolicyRequestModel> CreatePatch(ApiMachinePolicyRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiMachinePolicyRequestModel>();
			patch.Replace(x => x.IsDefault, model.IsDefault);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>be219089d89937706ad4796d72ca084b</Hash>
</Codenesium>*/