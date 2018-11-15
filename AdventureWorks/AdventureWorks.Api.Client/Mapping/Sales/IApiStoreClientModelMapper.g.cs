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
    <Hash>080d0bfee9b360fb53a92a42c8078969</Hash>
</Codenesium>*/