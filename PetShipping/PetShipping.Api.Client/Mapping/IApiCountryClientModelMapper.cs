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
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/