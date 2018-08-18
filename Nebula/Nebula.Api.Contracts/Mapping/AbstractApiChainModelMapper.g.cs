using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public abstract class AbstractApiChainModelMapper
	{
		public virtual ApiChainResponseModel MapRequestToResponse(
			int id,
			ApiChainRequestModel request)
		{
			var response = new ApiChainResponseModel();
			response.SetProperties(id,
			                       request.ChainStatusId,
			                       request.ExternalId,
			                       request.Name,
			                       request.TeamId);
			return response;
		}

		public virtual ApiChainRequestModel MapResponseToRequest(
			ApiChainResponseModel response)
		{
			var request = new ApiChainRequestModel();
			request.SetProperties(
				response.ChainStatusId,
				response.ExternalId,
				response.Name,
				response.TeamId);
			return request;
		}

		public JsonPatchDocument<ApiChainRequestModel> CreatePatch(ApiChainRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiChainRequestModel>();
			patch.Replace(x => x.ChainStatusId, model.ChainStatusId);
			patch.Replace(x => x.ExternalId, model.ExternalId);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.TeamId, model.TeamId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>43e9a3d24054587a3eaedae619d63db0</Hash>
</Codenesium>*/