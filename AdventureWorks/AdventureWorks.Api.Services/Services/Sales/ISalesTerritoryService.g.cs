using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface ISalesTerritoryService
        {
                Task<CreateResponse<ApiSalesTerritoryResponseModel>> Create(
                        ApiSalesTerritoryRequestModel model);

                Task<UpdateResponse<ApiSalesTerritoryResponseModel>> Update(int territoryID,
                                                                             ApiSalesTerritoryRequestModel model);

                Task<ActionResponse> Delete(int territoryID);

                Task<ApiSalesTerritoryResponseModel> Get(int territoryID);

                Task<List<ApiSalesTerritoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiSalesTerritoryResponseModel> ByName(string name);

                Task<List<ApiCustomerResponseModel>> Customers(int territoryID, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int territoryID, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSalesPersonResponseModel>> SalesPersons(int territoryID, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistories(int territoryID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d8fc048764324eaa9c139e8dfc0b72a9</Hash>
</Codenesium>*/