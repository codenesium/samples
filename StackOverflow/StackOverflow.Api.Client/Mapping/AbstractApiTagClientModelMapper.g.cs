using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiTagModelMapper
	{
		public virtual ApiTagClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTagClientRequestModel request)
		{
			var response = new ApiTagClientResponseModel();
			response.SetProperties(id,
			                       request.Count,
			                       request.ExcerptPostId,
			                       request.TagName,
			                       request.WikiPostId);
			return response;
		}

		public virtual ApiTagClientRequestModel MapClientResponseToRequest(
			ApiTagClientResponseModel response)
		{
			var request = new ApiTagClientRequestModel();
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
    <Hash>9b06dcb1305395f50886d1803afbc76e</Hash>
</Codenesium>*/