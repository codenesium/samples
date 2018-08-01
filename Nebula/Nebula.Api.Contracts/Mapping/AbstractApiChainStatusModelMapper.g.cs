using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public abstract class AbstractApiChainStatusModelMapper
	{
		public virtual ApiChainStatusResponseModel MapRequestToResponse(
			int id,
			ApiChainStatusRequestModel request)
		{
			var response = new ApiChainStatusResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiChainStatusRequestModel MapResponseToRequest(
			ApiChainStatusResponseModel response)
		{
			var request = new ApiChainStatusRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiChainStatusRequestModel> CreatePatch(ApiChainStatusRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiChainStatusRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>10bd07a9f7e3ef44b6465176ab2ea132</Hash>
</Codenesium>*/