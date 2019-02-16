using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesTerritoryMapper
	{
		SalesTerritory MapModelToBO(
			int territoryID,
			ApiSalesTerritoryServerRequestModel model);

		ApiSalesTerritoryServerResponseModel MapBOToModel(
			SalesTerritory item);

		List<ApiSalesTerritoryServerResponseModel> MapBOToModel(
			List<SalesTerritory> items);
	}
}

/*<Codenesium>
    <Hash>5eda3fbc6621bf6a8b81d30e04621daa</Hash>
</Codenesium>*/