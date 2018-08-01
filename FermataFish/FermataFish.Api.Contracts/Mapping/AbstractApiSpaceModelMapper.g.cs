using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
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
			                       request.StudioId);
			return response;
		}

		public virtual ApiSpaceRequestModel MapResponseToRequest(
			ApiSpaceResponseModel response)
		{
			var request = new ApiSpaceRequestModel();
			request.SetProperties(
				response.Description,
				response.Name,
				response.StudioId);
			return request;
		}

		public JsonPatchDocument<ApiSpaceRequestModel> CreatePatch(ApiSpaceRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceRequestModel>();
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.StudioId, model.StudioId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>776e09bb9da7b456dd51040dd4ccac4e</Hash>
</Codenesium>*/