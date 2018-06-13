using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ISalesOrderDetailService
        {
                Task<CreateResponse<ApiSalesOrderDetailResponseModel>> Create(
                        ApiSalesOrderDetailRequestModel model);

                Task<ActionResponse> Update(int salesOrderID,
                                            ApiSalesOrderDetailRequestModel model);

                Task<ActionResponse> Delete(int salesOrderID);

                Task<ApiSalesOrderDetailResponseModel> Get(int salesOrderID);

                Task<List<ApiSalesOrderDetailResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiSalesOrderDetailResponseModel>> GetProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>81c9b76264e9907bb8ccceff4a8aeeb1</Hash>
</Codenesium>*/