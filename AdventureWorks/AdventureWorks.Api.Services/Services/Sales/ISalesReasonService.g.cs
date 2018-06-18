using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ISalesReasonService
        {
                Task<CreateResponse<ApiSalesReasonResponseModel>> Create(
                        ApiSalesReasonRequestModel model);

                Task<ActionResponse> Update(int salesReasonID,
                                            ApiSalesReasonRequestModel model);

                Task<ActionResponse> Delete(int salesReasonID);

                Task<ApiSalesReasonResponseModel> Get(int salesReasonID);

                Task<List<ApiSalesReasonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> SalesOrderHeaderSalesReasons(int salesReasonID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>8fc613e6348112c48993069d2d27b5c4</Hash>
</Codenesium>*/