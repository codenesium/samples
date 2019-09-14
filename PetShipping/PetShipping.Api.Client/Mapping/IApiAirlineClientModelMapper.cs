using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiAirlineModelMapper
	{
		ApiAirlineClientResponseModel MapClientRequestToResponse(
			int id,
			ApiAirlineClientRequestModel request);

		ApiAirlineClientRequestModel MapClientResponseToRequest(
			ApiAirlineClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>7b94d409189f03d93f41782d582d2e88</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/