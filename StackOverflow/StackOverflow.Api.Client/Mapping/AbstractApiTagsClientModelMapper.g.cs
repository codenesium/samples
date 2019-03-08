using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiTagsModelMapper
	{
		public virtual ApiTagsClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTagsClientRequestModel request)
		{
			var response = new ApiTagsClientResponseModel();
			response.SetProperties(id,
			                       request.Count,
			                       request.ExcerptPostId,
			                       request.TagName,
			                       request.WikiPostId);
			return response;
		}

		public virtual ApiTagsClientRequestModel MapClientResponseToRequest(
			ApiTagsClientResponseModel response)
		{
			var request = new ApiTagsClientRequestModel();
			request.SetProperties(
				response.Count,
				response.ExcerptPostId,
				response.TagName,
				response.WikiPostId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>b9144875c67cceb3a6daadefa68ae30c</Hash>
</Codenesium>*/