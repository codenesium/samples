using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiTagModelMapper
	{
		public virtual ApiTagResponseModel MapRequestToResponse(
			int id,
			ApiTagRequestModel request)
		{
			var response = new ApiTagResponseModel();
			response.SetProperties(id,
			                       request.Count,
			                       request.ExcerptPostId,
			                       request.TagName,
			                       request.WikiPostId);
			return response;
		}

		public virtual ApiTagRequestModel MapResponseToRequest(
			ApiTagResponseModel response)
		{
			var request = new ApiTagRequestModel();
			request.SetProperties(
				response.Count,
				response.ExcerptPostId,
				response.TagName,
				response.WikiPostId);
			return request;
		}

		public JsonPatchDocument<ApiTagRequestModel> CreatePatch(ApiTagRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTagRequestModel>();
			patch.Replace(x => x.Count, model.Count);
			patch.Replace(x => x.ExcerptPostId, model.ExcerptPostId);
			patch.Replace(x => x.TagName, model.TagName);
			patch.Replace(x => x.WikiPostId, model.WikiPostId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>5748bfc3b55a024a63fdd32e67d4799a</Hash>
</Codenesium>*/