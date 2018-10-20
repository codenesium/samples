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
			                       request.Name,
			                       request.IsDeleted);
			return response;
		}

		public virtual ApiEventStatusRequestModel MapResponseToRequest(
			ApiEventStatusResponseModel response)
		{
			var request = new ApiEventStatusRequestModel();
			request.SetProperties(
				response.Name,
				response.IsDeleted);
			return request;
		}

		public JsonPatchDocument<ApiEventStatusRequestModel> CreatePatch(ApiEventStatusRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventStatusRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.IsDeleted, model.IsDeleted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8108b6f831af5d828744f4b1009e2866</Hash>
</Codenesium>*/