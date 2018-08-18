using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiExtensionConfigurationModelMapper
	{
		public virtual ApiExtensionConfigurationResponseModel MapRequestToResponse(
			string id,
			ApiExtensionConfigurationRequestModel request)
		{
			var response = new ApiExtensionConfigurationResponseModel();
			response.SetProperties(id,
			                       request.ExtensionAuthor,
			                       request.JSON,
			                       request.Name);
			return response;
		}

		public virtual ApiExtensionConfigurationRequestModel MapResponseToRequest(
			ApiExtensionConfigurationResponseModel response)
		{
			var request = new ApiExtensionConfigurationRequestModel();
			request.SetProperties(
				response.ExtensionAuthor,
				response.JSON,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiExtensionConfigurationRequestModel> CreatePatch(ApiExtensionConfigurationRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiExtensionConfigurationRequestModel>();
			patch.Replace(x => x.ExtensionAuthor, model.ExtensionAuthor);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>662de956829f311ca7acd0b6856fcb7c</Hash>
</Codenesium>*/