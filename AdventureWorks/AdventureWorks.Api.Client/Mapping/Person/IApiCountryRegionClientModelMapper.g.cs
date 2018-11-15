using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiCountryRegionModelMapper
	{
		ApiCountryRegionClientResponseModel MapClientRequestToResponse(
			string countryRegionCode,
			ApiCountryRegionClientRequestModel request);

		ApiCountryRegionClientRequestModel MapClientResponseToRequest(
			ApiCountryRegionClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>ba139977844d9e74e18bebdb777dd21e</Hash>
</Codenesium>*/