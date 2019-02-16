using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiVendorModelMapper
	{
		ApiVendorClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiVendorClientRequestModel request);

		ApiVendorClientRequestModel MapClientResponseToRequest(
			ApiVendorClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>3b79bb257b396a09ecbfbbeee2e49306</Hash>
</Codenesium>*/