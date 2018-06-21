using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>d521b4766899ebecdf2e8ca2487164a3</Hash>
</Codenesium>*/