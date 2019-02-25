using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesTerritoryMapper
	{
		SalesTerritory MapModelToEntity(
			int territoryID,
			ApiSalesTerritoryServerRequestModel model);

		ApiSalesTerritoryServerResponseModel MapEntityToModel(
			SalesTerritory item);

		List<ApiSalesTerritoryServerResponseModel> MapEntityToModel(
			List<SalesTerritory> items);
	}
}

/*<Codenesium>
    <Hash>eb4bb494f4a07405eaea5861295a2fb9</Hash>
</Codenesium>*/