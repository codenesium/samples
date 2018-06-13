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

                Task<List<ApiSalesReasonResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> SalesOrderHeaderSalesReasons(int salesReasonID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b800ea5798a182d4251f3415a41bbd3d</Hash>
</Codenesium>*/