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

                Task<List<ApiSalesPersonQuotaHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>2781d13a1b4a0ab877f9f409f034c108</Hash>
</Codenesium>*/