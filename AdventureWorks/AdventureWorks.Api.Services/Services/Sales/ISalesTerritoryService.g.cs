using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ISalesTerritoryService
        {
                Task<CreateResponse<ApiSalesTerritoryResponseModel>> Create(
                        ApiSalesTerritoryRequestModel model);

                Task<ActionResponse> Update(int territoryID,
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
    <Hash>491e4ffc0f1cfad55dbb96f1bfd59bf1</Hash>
</Codenesium>*/