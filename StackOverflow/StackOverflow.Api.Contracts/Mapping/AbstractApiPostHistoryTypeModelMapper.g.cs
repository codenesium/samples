using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiPostHistoryTypeModelMapper
	{
		public virtual ApiPostHistoryTypeResponseModel MapRequestToResponse(
			int id,
			ApiPostHistoryTypeRequestModel request)
		{
			var response = new ApiPostHistoryTypeResponseModel();
			response.SetProperties(id,
			                       request.Type);
			return response;
		}

		public virtual ApiPostHistoryTypeRequestModel MapResponseToRequest(
			ApiPostHistoryTypeResponseModel response)
		{
			var request = new ApiPostHistoryTypeRequestModel();
			request.SetProperties(
				response.Type);
			return request;
		}

		public JsonPatchDocument<ApiPostHistoryTypeRequestModel> CreatePatch(ApiPostHistoryTypeRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostHistoryTypeRequestModel>();
			patch.Replace(x => x.Type, model.Type);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>97cf9057662701945571b1781442bb46</Hash>
</Codenesium>*/