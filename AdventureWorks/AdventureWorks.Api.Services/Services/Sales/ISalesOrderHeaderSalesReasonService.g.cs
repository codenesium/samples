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

                Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>971b2e9b81bd6de70c1dff2dc0c9b780</Hash>
</Codenesium>*/