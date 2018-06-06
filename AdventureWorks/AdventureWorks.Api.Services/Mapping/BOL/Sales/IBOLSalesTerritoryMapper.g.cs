using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLSalesTerritoryMapper
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
    <Hash>a7e26f77ad28a6d6f7fa671023fd4e1b</Hash>
</Codenesium>*/