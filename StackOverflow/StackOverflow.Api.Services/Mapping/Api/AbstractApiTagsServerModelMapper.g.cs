using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiTagsServerModelMapper
	{
		public virtual ApiTagsServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTagsServerRequestModel request)
		{
			var response = new ApiTagsServerResponseModel();
			response.SetProperties(id,
			                       request.Count,
			                       request.ExcerptPostId,
			                       request.TagName,
			                       request.WikiPostId);
			return response;
		}

		public virtual ApiTagsServerRequestModel MapServerResponseToRequest(
			ApiTagsServerResponseModel response)
		{
			var request = new ApiTagsServerRequestModel();
			request.SetProperties(
				response.Count,
				response.ExcerptPostId,
				response.TagName,
				response.WikiPostId);
			return request;
		}

		public virtual ApiTagsClientRequestModel MapServerResponseToClientRequest(
			ApiTagsServerResponseModel response)
		{
			var request = new ApiTagsClientRequestModel();
			request.SetProperties(
				response.Count,
				response.ExcerptPostId,
				response.TagName,
				response.WikiPostId);
			return request;
		}

		public JsonPatchDocument<ApiTagsServerRequestModel> CreatePatch(ApiTagsServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTagsServerRequestModel>();
			patch.Replace(x => x.Count, model.Count);
			patch.Replace(x => x.ExcerptPostId, model.ExcerptPostId);
			patch.Replace(x => x.TagName, model.TagName);
			patch.Replace(x => x.WikiPostId, model.WikiPostId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>de93b0843b5b0db908e070db699e6db3</Hash>
</Codenesium>*/