using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiPostTypesModelMapper
	{
		public virtual ApiPostTypesResponseModel MapRequestToResponse(
			int id,
			ApiPostTypesRequestModel request)
		{
			var response = new ApiPostTypesResponseModel();
			response.SetProperties(id,
			                       request.Type);
			return response;
		}

		public virtual ApiPostTypesRequestModel MapResponseToRequest(
			ApiPostTypesResponseModel response)
		{
			var request = new ApiPostTypesRequestModel();
			request.SetProperties(
				response.Type);
			return request;
		}

		public JsonPatchDocument<ApiPostTypesRequestModel> CreatePatch(ApiPostTypesRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostTypesRequestModel>();
			patch.Replace(x => x.Type, model.Type);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>89a356f370f021a430485150e10f0c94</Hash>
</Codenesium>*/