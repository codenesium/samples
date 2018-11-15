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
    <Hash>bdee1d2d85f675e38443997dbd89b81f</Hash>
</Codenesium>*/