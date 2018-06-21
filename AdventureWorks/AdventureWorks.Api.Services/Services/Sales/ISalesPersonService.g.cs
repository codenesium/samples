using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>f6bd98f61a552501e20aeb71d71069b1</Hash>
</Codenesium>*/