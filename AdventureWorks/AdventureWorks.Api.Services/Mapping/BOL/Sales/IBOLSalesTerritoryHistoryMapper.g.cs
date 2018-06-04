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
			List<BOSalesTerritoryHistory> bos);
	}
}

/*<Codenesium>
    <Hash>ce7f90caa927b477f4182f4f21c9f265</Hash>
</Codenesium>*/