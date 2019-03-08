using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiPostLinksModelMapper
	{
		public virtual ApiPostLinksClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostLinksClientRequestModel request)
		{
			var response = new ApiPostLinksClientResponseModel();
			response.SetProperties(id,
			                       request.CreationDate,
			                       request.LinkTypeId,
			                       request.PostId,
			                       request.RelatedPostId);
			return response;
		}

		public virtual ApiPostLinksClientRequestModel MapClientResponseToRequest(
			ApiPostLinksClientResponseModel response)
		{
			var request = new ApiPostLinksClientRequestModel();
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
    <Hash>0be3ff77158e2df3340da95cbe1dc49a</Hash>
</Codenesium>*/