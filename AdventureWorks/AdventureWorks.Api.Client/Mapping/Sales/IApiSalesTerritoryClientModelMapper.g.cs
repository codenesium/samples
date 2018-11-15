using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiSalesTerritoryModelMapper
	{
		ApiSalesTerritoryClientResponseModel MapClientRequestToResponse(
			int territoryID,
			ApiSalesTerritoryClientRequestModel request);

		ApiSalesTerritoryClientRequestModel MapClientResponseToRequest(
			ApiSalesTerritoryClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>b133674fd2cfa62aecd051930f843a16</Hash>
</Codenesium>*/