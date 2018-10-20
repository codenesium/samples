using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesPersonService
	{
		Task<CreateResponse<ApiSalesPersonResponseModel>> Create(
			ApiSalesPersonRequestModel model);

		Task<UpdateResponse<ApiSalesPersonResponseModel>> Update(int businessEntityID,
		                                                          ApiSalesPersonRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiSalesPersonResponseModel> Get(int businessEntityID);

		Task<List<ApiSalesPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeadersBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistoriesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistoriesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStoreResponseModel>> StoresBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bdaaed6876cd0b8b8733f7318260e175</Hash>
</Codenesium>*/