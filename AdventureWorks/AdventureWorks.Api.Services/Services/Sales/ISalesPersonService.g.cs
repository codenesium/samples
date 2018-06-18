using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ISalesPersonService
        {
                Task<CreateResponse<ApiSalesPersonResponseModel>> Create(
                        ApiSalesPersonRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiSalesPersonRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiSalesPersonResponseModel> Get(int businessEntityID);

                Task<List<ApiSalesPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int salesPersonID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiStoreResponseModel>> Stores(int salesPersonID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>4739f13316a9232dba447bf7a1ae608a</Hash>
</Codenesium>*/