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
    <Hash>ce672131325a7ceb81eac884c92805b2</Hash>
</Codenesium>*/