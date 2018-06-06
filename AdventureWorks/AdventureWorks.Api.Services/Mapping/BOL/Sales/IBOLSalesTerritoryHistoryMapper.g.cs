using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLSalesTerritoryHistoryMapper
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
    <Hash>e69eb141bb10812d85ba5d16514cced0</Hash>
</Codenesium>*/