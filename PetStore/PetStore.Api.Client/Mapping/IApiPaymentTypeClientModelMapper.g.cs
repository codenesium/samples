using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public partial interface IApiPaymentTypeModelMapper
	{
		ApiPaymentTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPaymentTypeClientRequestModel request);

		ApiPaymentTypeClientRequestModel MapClientResponseToRequest(
			ApiPaymentTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>57ab42c62727a0b1f462e2256fbc806e</Hash>
</Codenesium>*/