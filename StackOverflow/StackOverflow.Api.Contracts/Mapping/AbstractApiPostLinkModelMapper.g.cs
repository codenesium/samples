using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiPostLinkModelMapper
	{
		public virtual ApiPostLinkResponseModel MapRequestToResponse(
			int id,
			ApiPostLinkRequestModel request)
		{
			var response = new ApiPostLinkResponseModel();
			response.SetProperties(id,
			                       request.CreationDate,
			                       request.LinkTypeId,
			                       request.PostId,
			                       request.RelatedPostId);
			return response;
		}

		public virtual ApiPostLinkRequestModel MapResponseToRequest(
			ApiPostLinkResponseModel response)
		{
			var request = new ApiPostLinkRequestModel();
			request.SetProperties(
				response.CreationDate,
				response.LinkTypeId,
				response.PostId,
				response.RelatedPostId);
			return request;
		}

		public JsonPatchDocument<ApiPostLinkRequestModel> CreatePatch(ApiPostLinkRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostLinkRequestModel>();
			patch.Replace(x => x.CreationDate, model.CreationDate);
			patch.Replace(x => x.LinkTypeId, model.LinkTypeId);
			patch.Replace(x => x.PostId, model.PostId);
			patch.Replace(x => x.RelatedPostId, model.RelatedPostId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>3435e4e39dd9154b41865d646281f46b</Hash>
</Codenesium>*/