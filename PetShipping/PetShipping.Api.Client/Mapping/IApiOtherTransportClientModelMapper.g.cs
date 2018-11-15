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
    <Hash>a6a9b5da6984718e901bdd48e93f400d</Hash>
</Codenesium>*/