using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiSpaceModelMapper
	{
		public virtual ApiSpaceResponseModel MapRequestToResponse(
			int id,
			ApiSpaceRequestModel request)
		{
			var response = new ApiSpaceResponseModel();
			response.SetProperties(id,
			                       request.Description,
			                       request.Name,
			                       request.IsDeleted);
			return response;
		}

		public virtual ApiSpaceRequestModel MapResponseToRequest(
			ApiSpaceResponseModel response)
		{
			var request = new ApiSpaceRequestModel();
			request.SetProperties(
				response.Description,
				response.Name,
				response.IsDeleted);
			return request;
		}

		public JsonPatchDocument<ApiSpaceRequestModel> CreatePatch(ApiSpaceRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceRequestModel>();
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.IsDeleted, model.IsDeleted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7a1b2e617639ce98cef295175fe3fc98</Hash>
</Codenesium>*/