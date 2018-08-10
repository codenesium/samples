using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLSalesTerritoryHistoryMapper
	{
		BOSalesTerritoryHistory MapModelToBO(
			int businessEntityID,
			ApiSalesTerritoryHistoryRequestModel model);

		ApiSalesTerritoryHistoryResponseModel MapBOToModel(
			BOSalesTerritoryHistory boSalesTerritoryHistory);

		List<ApiSalesTerritoryHistoryResponseModel> MapBOToModel(
			List<BOSalesTerritoryHistory> items);
	}
}

/*<Codenesium>
    <Hash>92207149276dedc5efc4d85e646c6b2b</Hash>
</Codenesium>*/