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
    <Hash>0a0eb624fdc071f46f004f40c86c4998</Hash>
</Codenesium>*/