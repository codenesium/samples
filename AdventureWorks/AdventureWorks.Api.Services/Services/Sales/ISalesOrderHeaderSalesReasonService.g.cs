using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ISalesOrderHeaderSalesReasonService
        {
                Task<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>> Create(
                        ApiSalesOrderHeaderSalesReasonRequestModel model);

                Task<ActionResponse> Update(int salesOrderID,
                                            ApiSalesOrderHeaderSalesReasonRequestModel model);

                Task<ActionResponse> Delete(int salesOrderID);

                Task<ApiSalesOrderHeaderSalesReasonResponseModel> Get(int salesOrderID);

                Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>7fb405f0bfedcb1b25733ad26537f160</Hash>
</Codenesium>*/