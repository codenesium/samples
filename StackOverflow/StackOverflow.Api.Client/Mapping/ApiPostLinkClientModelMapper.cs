using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public class ApiPostLinkModelMapper : IApiPostLinkModelMapper
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
    <Hash>27abf301c85f11b4db14526cd104856e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/