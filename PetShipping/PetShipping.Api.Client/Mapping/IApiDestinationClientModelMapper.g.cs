using PetShippingNS.Api.Contracts;
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
    <Hash>31c57adffc5187c15b95cae2410bc311</Hash>
</Codenesium>*/