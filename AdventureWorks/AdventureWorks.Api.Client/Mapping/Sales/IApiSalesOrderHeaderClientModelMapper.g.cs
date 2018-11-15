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
    <Hash>475fcc9a624fa818b484ddc64d444e62</Hash>
</Codenesium>*/