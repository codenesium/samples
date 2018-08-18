using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiConfigurationModelMapper
	{
		public virtual ApiConfigurationResponseModel MapRequestToResponse(
			string id,
			ApiConfigurationRequestModel request)
		{
			var response = new ApiConfigurationResponseModel();
			response.SetProperties(id,
			                       request.JSON);
			return response;
		}

		public virtual ApiConfigurationRequestModel MapResponseToRequest(
			ApiConfigurationResponseModel response)
		{
			var request = new ApiConfigurationRequestModel();
			request.SetProperties(
				response.JSON);
			return request;
		}

		public JsonPatchDocument<ApiConfigurationRequestModel> CreatePatch(ApiConfigurationRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiConfigurationRequestModel>();
			patch.Replace(x => x.JSON, model.JSON);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8e3c0307b402dea5d8a18f9fd2bfcf9d</Hash>
</Codenesium>*/