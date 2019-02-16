using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiCountryModelMapper
	{
		ApiCountryClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCountryClientRequestModel request);

		ApiCountryClientRequestModel MapClientResponseToRequest(
			ApiCountryClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>166d21bc90d3f5954b3cc53b946c08ee</Hash>
</Codenesium>*/