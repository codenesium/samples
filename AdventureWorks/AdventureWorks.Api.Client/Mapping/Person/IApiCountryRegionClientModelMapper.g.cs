using AdventureWorksNS.Api.Contracts;
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
    <Hash>ab50475a98ce66fad695caa1126ae46f</Hash>
</Codenesium>*/