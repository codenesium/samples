using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>2f36340dfc38738c76cfc04d1356ce78</Hash>
</Codenesium>*/