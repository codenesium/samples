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
			                       request.Name);
			return response;
		}

		public virtual ApiSpaceRequestModel MapResponseToRequest(
			ApiSpaceResponseModel response)
		{
			var request = new ApiSpaceRequestModel();
			request.SetProperties(
				response.Description,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiSpaceRequestModel> CreatePatch(ApiSpaceRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceRequestModel>();
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>6487317b646fea3f4b3148e328434d07</Hash>
</Codenesium>*/