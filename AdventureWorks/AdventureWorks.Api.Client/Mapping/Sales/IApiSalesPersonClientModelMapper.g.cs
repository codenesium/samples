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
    <Hash>24c56a39f48ece6c389443746a67f59a</Hash>
</Codenesium>*/