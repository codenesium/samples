using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiPostLinkModelMapper
	{
		public virtual ApiPostLinkClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostLinkClientRequestModel request)
		{
			var response = new ApiPostLinkClientResponseModel();
			response.SetProperties(id,
			                       request.CreationDate,
			                       request.LinkTypeId,
			                       request.PostId,
			                       request.RelatedPostId);
			return response;
		}

		public virtual ApiPostLinkClientRequestModel MapClientResponseToRequest(
			ApiPostLinkClientResponseModel response)
		{
			var request = new ApiPostLinkClientRequestModel();
			request.SetProperties(
				response.CreationDate,
				response.LinkTypeId,
				response.PostId,
				response.RelatedPostId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>22ca183705b867818c76a0ffe878e48d</Hash>
</Codenesium>*/