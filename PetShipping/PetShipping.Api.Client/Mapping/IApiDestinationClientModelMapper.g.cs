using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiDestinationModelMapper
	{
		ApiDestinationClientResponseModel MapClientRequestToResponse(
			int id,
			ApiDestinationClientRequestModel request);

		ApiDestinationClientRequestModel MapClientResponseToRequest(
			ApiDestinationClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>0f279b94712cbe3ffedca8c215f99a86</Hash>
</Codenesium>*/