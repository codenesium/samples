using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLSalesTerritoryMapper
	{
		BOSalesTerritory MapModelToBO(
			int territoryID,
			ApiSalesTerritoryRequestModel model);

		ApiSalesTerritoryResponseModel MapBOToModel(
			BOSalesTerritory boSalesTerritory);

		List<ApiSalesTerritoryResponseModel> MapBOToModel(
			List<BOSalesTerritory> items);
	}
}

/*<Codenesium>
    <Hash>eb9becd8145ff3db2444835d1f7502b1</Hash>
</Codenesium>*/