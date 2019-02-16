using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiSalesPersonModelMapper
	{
		ApiSalesPersonClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiSalesPersonClientRequestModel request);

		ApiSalesPersonClientRequestModel MapClientResponseToRequest(
			ApiSalesPersonClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>0ff2cff9fbfad0271b3ee0cfc1b2756b</Hash>
</Codenesium>*/