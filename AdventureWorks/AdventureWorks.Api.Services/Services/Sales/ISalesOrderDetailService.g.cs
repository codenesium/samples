using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiSalesOrderDetailResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSalesOrderDetailResponseModel>> ByProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>8b2fdc02ce635da8d3ffeed4214beeb5</Hash>
</Codenesium>*/