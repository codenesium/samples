using PetShippingNS.Api.Contracts;
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
    <Hash>cdbe077c4ca794a484be67eeb8b4bb3a</Hash>
</Codenesium>*/