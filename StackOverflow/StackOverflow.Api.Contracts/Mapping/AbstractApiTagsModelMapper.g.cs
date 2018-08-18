using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiTagsModelMapper
	{
		public virtual ApiTagsResponseModel MapRequestToResponse(
			int id,
			ApiTagsRequestModel request)
		{
			var response = new ApiTagsResponseModel();
			response.SetProperties(id,
			                       request.Count,
			                       request.ExcerptPostId,
			                       request.TagName,
			                       request.WikiPostId);
			return response;
		}

		public virtual ApiTagsRequestModel MapResponseToRequest(
			ApiTagsResponseModel response)
		{
			var request = new ApiTagsRequestModel();
			request.SetProperties(
				response.Count,
				response.ExcerptPostId,
				response.TagName,
				response.WikiPostId);
			return request;
		}

		public JsonPatchDocument<ApiTagsRequestModel> CreatePatch(ApiTagsRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTagsRequestModel>();
			patch.Replace(x => x.Count, model.Count);
			patch.Replace(x => x.ExcerptPostId, model.ExcerptPostId);
			patch.Replace(x => x.TagName, model.TagName);
			patch.Replace(x => x.WikiPostId, model.WikiPostId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9c8760b6ffa7755aa252f4259b0e4fb1</Hash>
</Codenesium>*/