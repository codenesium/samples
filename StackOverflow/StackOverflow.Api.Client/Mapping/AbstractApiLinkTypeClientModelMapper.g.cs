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
			                       request.Type);
			return response;
		}

		public virtual ApiLinkTypeClientRequestModel MapClientResponseToRequest(
			ApiLinkTypeClientResponseModel response)
		{
			var request = new ApiLinkTypeClientRequestModel();
			request.SetProperties(
				response.Type);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>e82734c3b6894a31695da9bd2113e82e</Hash>
</Codenesium>*/