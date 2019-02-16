using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiStoreModelMapper
	{
		ApiStoreClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiStoreClientRequestModel request);

		ApiStoreClientRequestModel MapClientResponseToRequest(
			ApiStoreClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>f12a6422b1eeb03500f2a0d727738e45</Hash>
</Codenesium>*/