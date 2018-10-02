using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public abstract class AbstractApiChainStatuModelMapper
	{
		public virtual ApiChainStatuResponseModel MapRequestToResponse(
			int id,
			ApiChainStatuRequestModel request)
		{
			var response = new ApiChainStatuResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiChainStatuRequestModel MapResponseToRequest(
			ApiChainStatuResponseModel response)
		{
			var request = new ApiChainStatuRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiChainStatuRequestModel> CreatePatch(ApiChainStatuRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiChainStatuRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>abccb2d0c14c2d9497ad543a35708e74</Hash>
</Codenesium>*/