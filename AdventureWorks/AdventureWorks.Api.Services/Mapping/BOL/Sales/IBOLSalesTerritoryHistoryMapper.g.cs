using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>4afa1769d79ae24de48450f068964fa5</Hash>
</Codenesium>*/