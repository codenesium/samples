using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiLinkTypeModelMapper
	{
		public virtual ApiLinkTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiLinkTypeClientRequestModel request)
		{
			var response = new ApiLinkTypeClientResponseModel();
			response.SetProperties(id,
			                       request.RwType);
			return response;
		}

		public virtual ApiLinkTypeClientRequestModel MapClientResponseToRequest(
			ApiLinkTypeClientResponseModel response)
		{
			var request = new ApiLinkTypeClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ccc07d19671b55f3ecb295377fb9fb4d</Hash>
</Codenesium>*/