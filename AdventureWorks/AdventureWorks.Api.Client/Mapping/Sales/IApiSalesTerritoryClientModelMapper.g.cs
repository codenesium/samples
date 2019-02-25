using AdventureWorksNS.Api.Contracts;
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
    <Hash>c41449129cab03a5ea9f7922d8382e9c</Hash>
</Codenesium>*/