using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiEventStatusModelMapper
	{
		public virtual ApiEventStatusResponseModel MapRequestToResponse(
			int id,
			ApiEventStatusRequestModel request)
		{
			var response = new ApiEventStatusResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiEventStatusRequestModel MapResponseToRequest(
			ApiEventStatusResponseModel response)
		{
			var request = new ApiEventStatusRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiEventStatusRequestModel> CreatePatch(ApiEventStatusRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventStatusRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>1d0b8da97e890551b97b6fd6a7dc0231</Hash>
</Codenesium>*/