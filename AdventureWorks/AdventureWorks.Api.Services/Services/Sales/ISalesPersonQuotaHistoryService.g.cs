using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ISalesPersonQuotaHistoryService
        {
                Task<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>> Create(
                        ApiSalesPersonQuotaHistoryRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiSalesPersonQuotaHistoryRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiSalesPersonQuotaHistoryResponseModel> Get(int businessEntityID);

                Task<List<ApiSalesPersonQuotaHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>404d2863ae58348eccc6ea440a5af569</Hash>
</Codenesium>*/