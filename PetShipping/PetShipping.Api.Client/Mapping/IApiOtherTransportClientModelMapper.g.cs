using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiOtherTransportModelMapper
	{
		ApiOtherTransportClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOtherTransportClientRequestModel request);

		ApiOtherTransportClientRequestModel MapClientResponseToRequest(
			ApiOtherTransportClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>fb823fece6a2473802d485928dafb2da</Hash>
</Codenesium>*/