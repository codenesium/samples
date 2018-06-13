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

                Task<List<ApiSalesTerritoryResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiSalesTerritoryResponseModel> GetName(string name);

                Task<List<ApiCustomerResponseModel>> Customers(int territoryID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int territoryID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiSalesPersonResponseModel>> SalesPersons(int territoryID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistories(int territoryID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f35d1db73591951d25f0bb25baa0d67c</Hash>
</Codenesium>*/