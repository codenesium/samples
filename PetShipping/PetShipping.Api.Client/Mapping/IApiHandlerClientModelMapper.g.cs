using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiHandlerModelMapper
	{
		ApiHandlerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiHandlerClientRequestModel request);

		ApiHandlerClientRequestModel MapClientResponseToRequest(
			ApiHandlerClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>f5a5e8aaca1d66ed5b6dbcf922e56b56</Hash>
</Codenesium>*/