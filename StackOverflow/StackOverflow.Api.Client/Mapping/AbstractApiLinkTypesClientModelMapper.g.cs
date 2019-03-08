using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiLinkTypesModelMapper
	{
		public virtual ApiLinkTypesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiLinkTypesClientRequestModel request)
		{
			var response = new ApiLinkTypesClientResponseModel();
			response.SetProperties(id,
			                       request.RwType);
			return response;
		}

		public virtual ApiLinkTypesClientRequestModel MapClientResponseToRequest(
			ApiLinkTypesClientResponseModel response)
		{
			var request = new ApiLinkTypesClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>77e246a38b77a7d935a414fe1e7c0c4f</Hash>
</Codenesium>*/