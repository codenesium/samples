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
			List<BOSalesTerritory> bos);
	}
}

/*<Codenesium>
    <Hash>468d30c3cdcd2e8f90788dcd270ce63e</Hash>
</Codenesium>*/