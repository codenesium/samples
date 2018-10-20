using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesTerritoryService
	{
		Task<CreateResponse<ApiSalesTerritoryResponseModel>> Create(
			ApiSalesTerritoryRequestModel model);

		Task<UpdateResponse<ApiSalesTerritoryResponseModel>> Update(int territoryID,
		                                                             ApiSalesTerritoryRequestModel model);

		Task<ActionResponse> Delete(int territoryID);

		Task<ApiSalesTerritoryResponseModel> Get(int territoryID);

		Task<List<ApiSalesTerritoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiSalesTerritoryResponseModel> ByName(string name);

		Task<List<ApiCustomerResponseModel>> CustomersByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeadersByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesPersonResponseModel>> SalesPersonsByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistoriesByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c6318e1cc694d714404bb1a6156afeb8</Hash>
</Codenesium>*/