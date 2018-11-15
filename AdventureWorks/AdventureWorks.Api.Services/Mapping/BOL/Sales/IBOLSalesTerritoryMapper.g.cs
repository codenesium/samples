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
			ApiSalesTerritoryServerRequestModel model);

		ApiSalesTerritoryServerResponseModel MapBOToModel(
			BOSalesTerritory boSalesTerritory);

		List<ApiSalesTerritoryServerResponseModel> MapBOToModel(
			List<BOSalesTerritory> items);
	}
}

/*<Codenesium>
    <Hash>7caa83806e3a6df183cf4e6eae5ccb83</Hash>
</Codenesium>*/