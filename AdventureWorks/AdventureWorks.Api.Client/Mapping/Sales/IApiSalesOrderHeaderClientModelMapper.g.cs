using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiSalesOrderHeaderModelMapper
	{
		ApiSalesOrderHeaderClientResponseModel MapClientRequestToResponse(
			int salesOrderID,
			ApiSalesOrderHeaderClientRequestModel request);

		ApiSalesOrderHeaderClientRequestModel MapClientResponseToRequest(
			ApiSalesOrderHeaderClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>406f2efff8fff4c931e48ca1320c2ea3</Hash>
</Codenesium>*/